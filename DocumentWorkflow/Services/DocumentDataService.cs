using System;
using System.Linq;
using DocumentWorkflow.Models;
using DocumentWorkflow.Models.Documents;
using DocumentWorkflow.Models.Documents.Statuses;
using DocumentWorkflow.Models.Entities;
using DocumentWorkflow.ViewModels;

namespace DocumentWorkflow.Services
{
    public class DocumentDataService
    {
        private DWContext context;

        public DocumentDataService(DWContext context)
        {
            this.context = context;
        }

        public IncomingDocument GetIncomingDocument(int id) =>
            context.IncomingDocuments.SingleOrDefault(d => d.Id == id);

        public OutgoingDocument GetOutgoingDocument(int id) =>
            context.OutgoingDocuments.SingleOrDefault(d => d.Id == id);

        public Document GetDocument(int id, DocumentTypeEnum typeEnum)
        {
            Document doc = null;
            if (typeEnum == DocumentTypeEnum.Incoming)
            {
                doc = GetIncomingDocument(id);
            }
            if (typeEnum == DocumentTypeEnum.Outgoing)
            {
                doc = GetOutgoingDocument(id);
            }
            return doc;
        }

        public void UpdateIncomingDocument(IncomingDocument doc)
        {
            context.IncomingDocuments.Update(doc);
            context.SaveChanges();
        }

        public void UpdateOutgoingDocument(OutgoingDocument doc)
        {
            context.OutgoingDocuments.Update(doc);
            context.SaveChanges();
        }

        public void Update(Document doc)
        {
            if (doc.GetDocumentTypeEnum() == DocumentTypeEnum.Incoming)
            {
                UpdateIncomingDocument((IncomingDocument)doc);
            }
            if (doc.GetDocumentTypeEnum() == DocumentTypeEnum.Outgoing)
            {
                UpdateOutgoingDocument((OutgoingDocument)doc);
            }
        }

        public void CreateIncomingDocument(IncomingDocument doc)
        {
            context.IncomingDocuments.Add(doc);
            context.SaveChanges();
            doc.Number = "Вх-" + DateTime.Now.Year + "-" + doc.Id;
            context.SaveChanges();
        }

        public void CreateOutgoingDocument(OutgoingDocument doc)
        {
            context.OutgoingDocuments.Add(doc);
            context.SaveChanges();
            doc.Number = "Исх-" + DateTime.Now.Year + "-" + doc.Id;
            context.SaveChanges();
        }

        public DocumentsVM GetListVM()
        {
            var vm = new DocumentsVM();
            var incomingDoc = context.IncomingDocuments.Select(d => (Document)d);
            var outgoingDoc = context.OutgoingDocuments.Select(d => (Document)d);
            vm.Documents = incomingDoc.AsEnumerable().Union(outgoingDoc)
                .Where(d => d.StatusEnum != StatusEnum.Archive)
                .OrderBy(d => d.Date)
                .ToList();
            return vm;
        }
    }
}