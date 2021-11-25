using DocumentWorkflow.Models.Documents;

namespace DocumentWorkflow.Models.Entities
{
    public class OutgoingDocument : Document
    {
        public string Theme { get; set; } //Тема
        public string Addressee { get; set; } //Адресат
        public string Signer { get; set; } //Подписант
        public int? IncomingDocumentId { get; set; }
    }
}