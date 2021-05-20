using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;
using FhirPatient = Hl7.Fhir.Model.Patient;
using Patient = FhirApp.Models.Patient;
using System.Text.RegularExpressions;
using System;

namespace FhirApp.Adapters
{
    /// <summary>
    ///     Adapter that makes queries to the hdap server.
    /// </summary>
    public class PatientAdapter
    {
        private Dictionary<string, Patient> patientRepo = new Dictionary<string, Patient>();

        /// <summary>
        ///     Returns the patient associated with the identifier.
        /// </summary>
        /// <param name="id">The (unique) identifier.</param>
        /// <returns>The associated patient.</returns>
        public Patient GetPatient(string id)
        {
            try
            {
                return this.patientRepo[id];
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     Method that will return all dummy data.
        /// </summary>
        /// <returns>A list of <see cref="Models.Patients"/>.</returns>
        public IEnumerable<Patient> GetPatients()
        {
            if (!this.patientRepo.Any())
            {
                this.FetchInitialPatients();
            }

            return this.patientRepo.Values.ToList();
        }

        /// <summary>
        ///     Method that will fetch all dummy data.
        /// </summary>
        public void FetchInitialPatients()
        {
            try
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

                        var patientBundle = client.Search<FhirPatient>(patientQuery);
                        var patient = patientBundle.Entry.First().Resource as FhirPatient;
                        var patientToAdd = new Patient
                        {
                            Name = patient.Name.First().ToString(),
                            BirthDate = patient.BirthDate,
                            Id = patient.Id,
                            Gender = patient.Gender?.ToString(),
                            MaritalStatus = patient.MaritalStatus?.Text ?? "Unknown"
                        };

                        this.patientRepo.TryAdd(patient.Id, patientToAdd);
                    }
                }            
            }
            catch
            {
                Console.Write("Unable to fetch patients");
            }
        }

        /// <summary>
        ///     Updates the patient with the given id.
        /// </summary>
        /// <param name="id">Id of the patient.</param>
        /// <param name="patient">The patient model.</param>
        public void Update(string id, Patient patient)
        {
            this.patientRepo[id] = patient;
        }
    }
}
