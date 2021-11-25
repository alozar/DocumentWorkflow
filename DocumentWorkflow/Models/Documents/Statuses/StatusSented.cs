namespace DocumentWorkflow.Models.Documents.Statuses
{
    public class StatusSented : Status
    {
        public override StatusEnum Name => StatusEnum.Sented;

        public override string Class => "fa-paper-plane";

        public override string Text => "Отправлен";

        public override Status Next() => new StatusArchive(DocumentTypeEnum.Outgoing);

        public override Status Prev() => new StatusSignature();
    }
}
