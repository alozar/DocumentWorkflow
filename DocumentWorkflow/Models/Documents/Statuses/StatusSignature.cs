namespace DocumentWorkflow.Models.Documents.Statuses
{
    public class StatusSignature : Status
    {
        public override StatusEnum Name => StatusEnum.Signature;

        public override string Class => "fa-signature";

        public override string Text => "На подпись";

        public override Status Next() => new StatusSented();

        public override Status Prev() => new StatusRegistered(DocumentTypeEnum.Outgoing);
    }
}
