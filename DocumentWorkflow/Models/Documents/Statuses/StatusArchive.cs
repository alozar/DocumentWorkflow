using System;

namespace DocumentWorkflow.Models.Documents.Statuses
{
    public class StatusArchive : Status
    {
        public StatusArchive(DocumentTypeEnum typeEnum)
        {
            this.typeEnum = typeEnum;
        }
        public override StatusEnum Name => StatusEnum.Archive;

        public override string Class => "fa-archive";

        public override string Text => "В архиве";

        public override Status Next() => null;

        public override Status Prev()
        {
            if (typeEnum == DocumentTypeEnum.Incoming)
                return new StatusWork();
            if (typeEnum == DocumentTypeEnum.Outgoing)
                return new StatusSignature();
            throw new Exception("Для документа типа " + "" + " не реализована цепочка статусов");
        }
    }
}
