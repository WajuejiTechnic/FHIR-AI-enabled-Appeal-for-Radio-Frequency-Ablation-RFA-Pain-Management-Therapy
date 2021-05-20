using Hl7.Fhir.Model;
using System.Collections.Generic;
using System.Linq;
using FhirPatient = Hl7.Fhir.Model.Patient;

namespace FhirApp.Models
{
    /// <summary>
    ///     Model that represents a patient. Will be transformed into JSON.
    /// </summary>
    public class Patient
    {
        /// <summary>
        ///     The id of the patient.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Name of the patient.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Birthdate of the patient.
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        ///     The gender of the patient.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        ///     The marital status of the patient.
        /// </summary>
        public string MaritalStatus { get; set; }

        /// <summary>
        ///     Any extra notes the doctor has.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        ///     The appeal template for this patient.
        /// </summary>
        public string AppealTemplate { get; set; }

        /// <summary>
        ///     Whther the patient has had step therapy.
        /// </summary>
        public bool StepTherapy { get; set; }

        /// <summary>
        ///     Whether the case has been submitted.
        /// </summary>
        public bool HasBeenSubmitted { get; set; }

        /// <summary>
        ///     Whether efficacy was a reason to appeal.
        /// </summary>
        public bool Efficacy { get; set; }

        /// <summary>
        ///     Whether cost was a reason to appeal.
        /// </summary>
        public bool Cost { get; set; }

        /// <summary>
        ///     Whether side effects was a reason to appeal.
        /// </summary>
        public bool SideEffect { get; set; }

        /// <summary>
        ///     Whether patient factors were a reason to appeal.
        /// </summary>
        public bool PatientFactors { get; set; }

        /// <summary>
        ///     Any additional information.
        /// </summary>
        public string Information { get; set; }
    }
}
