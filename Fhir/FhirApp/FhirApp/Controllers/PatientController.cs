using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FhirApp.Adapters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hl7.Fhir.Model;

namespace FhirApp.Controllers
{
    /// <summary>
    ///     Controller used for retrieving patients.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        /// <summary>
        ///     Gets all patients.
        /// </summary>
        /// <returns>All patients.</returns>
        [HttpGet]
        public IEnumerable<Models.Patient> Get()
        {
            var patients = ServiceEnvironment.PatientAdapter.GetPatients();

            return patients;
        }

        /// <summary>
        ///     Gets a specific patient.
        /// </summary>
        /// <returns>A patient specified by the id.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var patient = ServiceEnvironment.PatientAdapter.GetPatient(id);

            if (patient == null)
            {
                return NotFound(id);
            }

            return Ok(patient);
        }

        /// <summary>
        ///     Updates a patient.
        /// </summary>
        /// <param name="id">Id of the patient.</param>
        /// <param name="patient">The updated patient.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        public IActionResult PutTodoItem(string id, Models.Patient patient)
        {
            if (id == null)
            {
                return BadRequest();
            }

            ServiceEnvironment.PatientAdapter.Update(id, patient);
            return NoContent();
        }
    }
}