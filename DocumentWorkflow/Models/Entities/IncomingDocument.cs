using DocumentWorkflow.Models.Documents;

namespace DocumentWorkflow.Models.Entities
{
    public class IncomingDocument : Document
    {
        public string Applicant { get; set; } //Заявитель
    }
}