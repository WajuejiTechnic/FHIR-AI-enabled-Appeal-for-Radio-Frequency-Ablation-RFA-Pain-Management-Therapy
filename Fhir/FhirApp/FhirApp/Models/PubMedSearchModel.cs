using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FhirApp.Models
{
    /// <summary>
    ///     Represents PubMed search results.
    /// </summary>
    public class PubMedSearchModel
    {
        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("esearchresult")]
        public ESearchResult Result { get; set; }
    }

    public class Header
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public class ESearchResult
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("retmax")]
        public int RetMax { get; set; }

        [JsonProperty("retstart")]
        public int RetStart { get; set; }

        [JsonProperty("idlist")]
        public List<string> IdList { get; set; }

        [JsonProperty("translationset")]
        public List<string> TranslationSet { get; set; }

        [JsonProperty("querytranslation")]
        public string QueryTranslation { get; set; }
    }

    public class TranslationStack
    {
        [JsonProperty("term")]
        public string Term { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("explode")]
        public string Explode { get; set; }
    }
}
