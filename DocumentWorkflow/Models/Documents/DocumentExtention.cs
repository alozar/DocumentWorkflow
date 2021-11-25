using DocumentWorkflow.Models.Documents.Statuses;
using DocumentWorkflow.Models.Entities;
using System;

namespace DocumentWorkflow.Models.Documents
{
    public static class DocumentExtention
    {
        public static Status GetStatus(this Document doc) =>
            StatusFactory.Get(doc.StatusEnum, doc.GetDocumentTypeEnum());

        public static DocumentTypeEnum GetDocumentTypeEnum(this Document doc)
        {
            if (doc is IncomingDocument)
                return DocumentTypeEnum.Incoming;
            if (doc is OutgoingDocument)
                return DocumentTypeEnum.Outgoing;
            throw new Exception("Для данного типа документа не реализован enum");
        }
    }
}