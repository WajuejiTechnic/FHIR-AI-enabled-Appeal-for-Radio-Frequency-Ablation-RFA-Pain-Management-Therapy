using FhirApp.Adapters;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class PubMedAdapterTest
    {
        private PubMedAdapter uut;

        [SetUp]
        public void Setup()
        {
            this.uut = new PubMedAdapter();
        }

        [Test]
        public void UriParsesCorrectly()
        {
            const string expected = "http://eutils.ncbi.nlm.nih.gov/entrez/eutils/esearch.fcgi?db=pmc&retmode=json&retmax=1000&term=%22RadioFrequency%20Ablation%22[MeSH%20Terms]+AND+%22Clinical%20Trial%22[ptyp]";

            var args = new string[] { "\"RadioFrequency Ablation\"[MeSH Terms]", "\"Clinical Trial\"[ptyp]" };
            var parsed = this.uut.ParseUri(args);
            Assert.That(parsed, Is.EqualTo(expected));
        }

        [Test]
        public async Task RetrievesResults()
        {
            var args = new string[] { "\"RadioFrequency Ablation\"[MeSH Terms]", "\"Back Pain\"[MeSH Terms]", "\"Clinical Trial\"[ptyp]" };
            var articles = await this.uut.RetrieveArticleIds(args);

            Assert.That(articles.Result.IdList.Count, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public async Task RetrievesArticles()
        {
            var xml = await this.uut.RetrieveResults();
            Assert.NotNull(xml);
        }
    }
}