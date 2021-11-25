using DocumentWorkflow.Models.Documents.Statuses;
using System;

namespace DocumentWorkflow.Models.Documents
{
    public abstract class Document
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Number { get; set; }
        public string Content { get; set; }
        public StatusEnum StatusEnum { get; set; }
    }
}