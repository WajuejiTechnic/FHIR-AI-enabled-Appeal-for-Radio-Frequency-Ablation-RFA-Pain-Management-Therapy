using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FhirApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        /// <summary>
        ///     Gets the template based on a specific patient.
        /// </summary>
        /// <returns>A template with information provided by the patient.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var patient = ServiceEnvironment.PatientAdapter.GetPatient(id);

            if (patient == null)
            {
                return NotFound(id);
            }

            if (patient.AppealTemplate != null)
            {
                return Ok(patient);
            }

            var template = await ServiceEnvironment.TemplateAdapter.GenerateTemplate(patient);

            patient.AppealTemplate = template;
            ServiceEnvironment.PatientAdapter.Update(patient.Id, patient);
            return Ok(patient);
        }
    }
}