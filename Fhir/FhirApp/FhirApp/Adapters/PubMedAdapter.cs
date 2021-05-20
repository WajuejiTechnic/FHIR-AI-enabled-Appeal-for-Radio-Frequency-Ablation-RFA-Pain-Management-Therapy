using FhirApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml;

[assembly: InternalsVisibleTo("UnitTests")]

namespace FhirApp.Adapters
{
    /// <summary>
    ///     Performs searches on the PubMed databse.
    /// </summary>
    public class PubMedAdapter
    {
        const string BaseSearchUrl = @"http://eutils.ncbi.nlm.nih.gov/entrez/eutils/esearch.fcgi?db=pmc&retmode=json&retmax=1000&term=";
        const string BaseArticleUrl = @"http://eutils.ncbi.nlm.nih.gov/entrez/eutils/efetch.fcgi?db=pmc&id=";

        public async Task<List<PubMedArticle>> RetrieveResults()
        {
            var args = new string[] { "\"RadioFrequency Ablation\"[MeSH Terms]", "\"Back Pain\"[MeSH Terms]", "\"Clinical Trial\"[ptyp]" };
            var articles = await this.RetrieveArticleIds(args);

            var results = new List<PubMedArticle>();

            foreach (var id in articles.Result.IdList)
            {
                try
                {
                    if (results.Count == 10)
                    {
                        break;
                    }

                    var article = await this.RetrieveArticle(id);
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(article);
                    var text = xmlDoc.GetElementsByTagName("body");

                    if (text == null || text.Count == 0) continue;

                    var matches = RegexSearch.GetMatches(text[0].InnerText);

                    if (matches.Any())
                    {
                        if (matches.Last().Length > 500) continue;

                        var authors = xmlDoc.GetElementsByTagName("contrib");
                        var author = authors[0].SelectSingleNode("name").SelectSingleNode("surname").InnerText;

                        var pubDate = xmlDoc.GetElementsByTagName("pub-date")[0].SelectSingleNode("year").InnerText;
                        var result = new PubMedArticle
                        {
                            Excerpt = matches.Last(),
                            Author = author,
                            PubYear = pubDate,
                            Id = id
                        };

                        results.Add(result);
                    }
                }
                catch
                {
                    // we can only request so many articles at a time
                    continue;
                }                
            }

            return results;
        }

        /// <summary>
        ///     Gets article ids from PubMed databse.
        /// </summary>
        /// <param name="searchTerms">List of search terms.</param>
        /// <returns>A model representing the search results.</returns>
        internal async Task<PubMedSearchModel> RetrieveArticleIds(IEnumerable<string> searchTerms)
        {
            var url = this.ParseUri(searchTerms);

            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync(url);

            try
            {
                return JsonConvert.DeserializeObject<PubMedSearchModel>(content);
            }
            catch(Exception e)
            {
                Console.Write($"Error deserializing search results: {e}");
            }
            finally
            {
                httpClient.Dispose();
            }

            return null;
        }

        /// <summary>
        ///     Retrieves the article specified.
        /// </summary>
        /// <param name="id">The id of the article.</param>
        /// <returns>An xml representation of the article.</returns>
        internal async Task<string> RetrieveArticle(string id)
        {
            var httpClient = new HttpClient();
            var url = BaseArticleUrl + id;

            return await httpClient.GetStringAsync(url);
        }

        /// <summary>
        ///     Parses arguments into a Uri safe string.
        /// </summary>
        /// <param name="args">The search terms.</param>
        /// <returns>A complete Uri string.</returns>
        internal string ParseUri(IEnumerable<string> args)
        {
            var returnVal = BaseSearchUrl;
            foreach (var argument in args)
            {
                var parsed = Uri.EscapeUriString(argument);
                returnVal += parsed;

                if (!args.Last().Equals(argument))
                {
                    returnVal += "+AND+";
                }
            }

            return returnVal;
        }
    }
}
