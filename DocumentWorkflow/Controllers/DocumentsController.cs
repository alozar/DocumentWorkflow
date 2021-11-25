using Microsoft.AspNetCore.Mvc;
using DocumentWorkflow.Services;
using DocumentWorkflow.Models.Documents;
using DocumentWorkflow.Models.Documents.Statuses;
using DocumentWorkflow.Models.Entities;

namespace DocumentWorkflow.Controllers
{
    public class DocumentsController : Controller
    {
        private DocumentDataService dataService;

        public DocumentsController(DocumentDataService dataService)
        {
            this.dataService = dataService;
        }

        public IActionResult Index()
        {
            return View(dataService.GetListVM());
        }

        private object statusJson(Status status) =>
            new { Name = status.Name.ToString(), status.Class, status.Text };

        public IActionResult NextStatusUpdate(int? id, DocumentTypeEnum? typeEnum)
        {
            if (!id.HasValue || !typeEnum.HasValue)
                return Json(-1);
            var doc = dataService.GetDocument(id.Value, typeEnum.Value);
            if (doc is null)
                return Json(-2);
            var newStatus = doc.GetStatus().Next();
            if (newStatus is null)
                return Json(-3);
            doc.StatusEnum = newStatus.Name;
            dataService.Update(doc);
            return Json(statusJson(newStatus));
        }

        public IActionResult NextStatus(StatusEnum? statusEnum, DocumentTypeEnum? typeEnum)
        {
            if (!statusEnum.HasValue || !typeEnum.HasValue)
                return Json(-1);
            var nextStatus = StatusFactory.Get(statusEnum.Value, typeEnum.Value).Next();
            if (nextStatus is null)
                return Json(-2);
            return Json(statusJson(nextStatus));
        }

        public IActionResult PrevStatus(StatusEnum? statusEnum, DocumentTypeEnum? typeEnum)
        {
            if (!statusEnum.HasValue || !typeEnum.HasValue)
                return Json(-1);
            var prevStatus = StatusFactory.Get(statusEnum.Value, typeEnum.Value).Prev();
            if (prevStatus is null)
                return Json(-2);
            return Json(statusJson(prevStatus));
        }

        public IActionResult Details(int? id, DocumentTypeEnum? typeEnum)
        {
            if (!id.HasValue || !typeEnum.HasValue)
                return Json(-1);
            if(typeEnum == DocumentTypeEnum.Incoming )
            {

                var doc = dataService.GetIncomingDocument(id.Value);
                if (doc is null)
                    return Json(-2);
                return Json(new { doc, status = statusJson(doc.GetStatus()) });
            }
            if (typeEnum == DocumentTypeEnum.Outgoing)
            {
                var doc = dataService.GetOutgoingDocument(id.Value);
                if (doc is null)
                    return Json(-3);
                return Json(new { doc, status = statusJson(doc.GetStatus()) });
            }
            return Json(-4);
        }

        public IActionResult Save(IncomingDocument doc, string action)
        {
            if (doc == null || action == null)
                return Json(-1);
            if (action == "Create")
            {
                dataService.CreateIncomingDocument(doc);
            }
            if (action == "Update")
            {
                dataService.UpdateIncomingDocument(doc);
            }
            return Json(0);
        }
    }
}