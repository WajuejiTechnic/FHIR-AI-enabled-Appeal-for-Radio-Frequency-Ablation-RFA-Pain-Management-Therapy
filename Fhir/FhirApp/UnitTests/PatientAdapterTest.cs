using FhirApp.Adapters;
using Hl7.Fhir.Rest;
using NUnit.Framework;
using Hl7.Fhir.Model;
using System.Text.RegularExpressions;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class PatientAdapterTests
    {
        private PatientAdapter uut;

        [SetUp]
        public void Setup()
        {
            this.uut = new PatientAdapter();
        }

        [Test]
        public void RetrievesResults()
        {
            var client = new FhirClient("https://apps.hdap.gatech.edu/gt-fhir/fhir");
            var query = new SearchParams();

            var backPainCode = "279039007";

            query.Add("code", backPainCode);
            query.LimitTo(20);

            var bundle = client.Search<Condition>(query);

            foreach (Bundle.EntryComponent entry in bundle.Entry)
            {
                if (entry.Resource is Condition c)
                {
                    var patientString = c.Subject.Reference;
                    var id = Regex.Match(patientString, @"\d+");
                    var patientQuery = new string[] { $"_id={id.Value}" };

                    var patientBundle = client.Search<Patient>(patientQuery);
                    var patient = patientBundle.Entry.First().Resource as Patient;

                    Assert.That(patient.Id, Is.EqualTo(id.Value));
                    Assert.That(c.Code.Coding.First().Code, Is.EqualTo(backPainCode));
                }
            }
        }
    }
}