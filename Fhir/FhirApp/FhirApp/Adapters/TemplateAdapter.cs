using FhirApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FhirApp.Adapters
{
    public class TemplateAdapter
    {
        public async Task<string> GenerateTemplate(Patient patient)
        {
            var entries = await ServiceEnvironment.PubMedAdapter.RetrieveResults();

            var formattedEntries = string.Empty;

            if (entries.Any())
            {
                formattedEntries = "I have attached these excerpts that contain information supporting my decision:\n\n";
                foreach (var entry in entries)
                {
                    formattedEntries = string.Concat(formattedEntries, entry.ToString());
                }
            }

            var notes = string.Empty;
            if (patient.Information != null && !patient.Information.Equals(string.Empty))
            {
                notes = $"I have taken the following notes about the patient: {patient.Information}\n";
            }

            var additionalReasons = string.Empty;
            if (patient.SideEffect || patient.Efficacy || patient.Cost)
            {
                var sideEffect = patient.SideEffect ? "side effects of current treatment" + ((patient.Cost || patient.Efficacy) ? "," : string.Empty) : string.Empty;
                var cost = patient.Cost ? "cost of current treatment" + (patient.Efficacy ? "," : string.Empty) : string.Empty;
                var efficacy = patient.Efficacy ? "efficacy of current treatment" : string.Empty;
                additionalReasons = $" for the following reasons: {sideEffect} {cost} {efficacy}";
            }

            var reasonForDenial = "investigational";

            var templateString =
                $"{DateTime.Now.ToLongDateString()}\n" +
                "Attn: Medical Director)\n" +
                "ACME Health Insurance\n" +
                "123 Fake Street\n" +
                "Kalamazoo, MI 12345 \n" +
                "RE: Denial of Radiofrequency Ablation procedure\n" +
                $"{patient.Name}\n" +
                "Policy no. 54321\n" +
                $"{patient.BirthDate}\n\n" +
                "Dear Medical Director:\n" +
                $"I am writing to appeal ACME Health Insurance’s recent denial of benefits for my patient, {patient.Name} for treatment of lower back pain utilizing a procedure called Radiofrequency Ablation{additionalReasons}. " +
                $"The denial states the procedure is {reasonForDenial} and I strongly dispute those findings. My recommended treatment, Radiofrequency Ablation has been successfully used in many cases (Patel et al., 2012, " +
                $"PMID: 22299761; Kapural et al., 2013, PMID: 23279658; Joo et al., 2013; Fischgrund et al., 2018, PMID: 29423885). {patient.Name} has been thoroughly evaluated and has been diagnosed with lower back pain. " +
                "Enclosed with this letter is the original documentation submitted and I request that you review the information again with particular attention to the patient’s history of lower back pain which has been ongoing " +
                "since [July 1, 2018]. Numerous conservative attempts at treatment have been attempted and failed, such as " +
                $"3 months of conservative therapeutic management, including nonsteroidal anti-inflammatory medications, chiropractic therapy, physical therapy, and a home exercise program. Despite these attempts, {patient.Name} has " +
                "received no relief from symptoms and is currently suffering from chronic low back pain. As a result, the patient cannot work as usual and all other daily life activities are greatly affected. I have included the following " +
                "documents to confirm diagnosis, including the medical record on history, physical and radiographic evaluation reports. Based on these findings and our previous attempts at conservative treatments, I believe it is medically " +
                $"necessary to move forward and schedule {patient.Name} for this procedure. {notes}{formattedEntries}I firmly believe that {patient.Name} is an excellent candidate for Radiofrequency Ablation. I request your immediate reconsideration of coverage for this " +
                "procedure. Thank you for your attention to this matter, and I look forward to your response. Please contact me if you have additional questions.\n" +
                "Sincerely,\n" +
                "John Smith MD\n" +
                "Kalamazoo Hospital";

            return templateString;
        }
    }
}
