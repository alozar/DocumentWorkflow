using DocumentWorkflow.Models.Entities;
using System;

namespace DocumentWorkflow.Models.Documents.Statuses
{
    public class StatusRegistered : Status
    {
        public StatusRegistered(DocumentTypeEnum typeEnum)
        {
            this.typeEnum = typeEnum;
        }
        public override StatusEnum Name => StatusEnum.Registered;

        public override string Class => "fa-registered";

        public override string Text => "Зарегистрирован";

        public override Status Next()
        {
            if (typeEnum == DocumentTypeEnum.Incoming)
                return new StatusWork();
            if (typeEnum == DocumentTypeEnum.Outgoing)
                return new StatusSignature();
            throw new Exception("Для документа типа " + "" + " не реализована цепочка статусов");
        }

        public override Status Prev() => null;
    }
}