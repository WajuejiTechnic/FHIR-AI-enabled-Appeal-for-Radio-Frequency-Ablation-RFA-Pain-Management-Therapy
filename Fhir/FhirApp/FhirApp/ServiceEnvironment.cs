using FhirApp.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FhirApp
{
    /// <summary>
    ///     Environment that keeps track of the state of the app.
    /// </summary>
    public static class ServiceEnvironment
    {
        /// <summary>
        ///     Initializes the service environment.
        /// </summary>
        public static void Initialize()
        {
            PatientAdapter = new PatientAdapter();
            PatientAdapter.FetchInitialPatients();

            PubMedAdapter = new PubMedAdapter();
            TemplateAdapter = new TemplateAdapter();
        }

        /// <summary>
        ///     The patient adapter.
        /// </summary>
        public static PatientAdapter PatientAdapter { get; private set; }

        /// <summary>
        ///     The template adapter.
        /// </summary>
        public static TemplateAdapter TemplateAdapter { get; private set; }

        /// <summary>
        ///     The pubmed adapter.
        /// </summary>
        public static PubMedAdapter PubMedAdapter { get; private set; }
    }
}
