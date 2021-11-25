namespace DocumentWorkflow.Models.Documents.Statuses
{
    public class StatusWork : Status
    {
        public override StatusEnum Name => StatusEnum.Work;

        public override string Class => "fa-pen";

        public override string Text => "В работе";

        public override Status Next() => new StatusArchive(DocumentTypeEnum.Incoming);

        public override Status Prev() => new StatusRegistered(DocumentTypeEnum.Incoming);
    }
}
