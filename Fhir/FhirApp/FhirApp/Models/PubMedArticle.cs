namespace FhirApp.Models
{
    /// <summary>
    ///     Model that represents a pub med article.
    /// </summary>
    public class PubMedArticle
    {
        /// <summary>
        ///     The relevant excerpt.
        /// </summary>
        public string Excerpt { get; set; }

        /// <summary>
        ///     The author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        ///     The publication year.
        /// </summary>
        public string PubYear { get; set; }

        /// <summary>
        ///     The PubMed ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Creates a string representation.
        /// </summary>
        /// <returns>A string representation of the article.</returns>
        public override string ToString()
        {
            return $"{this.Excerpt} ({this.Author} et al., {this.PubYear}, PMID: {this.Id})\n\n";
        }
    }
}
