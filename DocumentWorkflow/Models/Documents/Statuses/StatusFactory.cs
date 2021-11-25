using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentWorkflow.Models.Documents.Statuses
{
    public static class StatusFactory
    {
        public static Status Get(StatusEnum statusEnum, DocumentTypeEnum typeEnum)
        {
            switch (statusEnum)
            {
                case StatusEnum.Registered:
                    return new StatusRegistered(typeEnum);
                case StatusEnum.Work:
                    return new StatusWork();
                case StatusEnum.Archive:
                    return new StatusArchive(typeEnum);
                case StatusEnum.Signature:
                    return new StatusSignature();
                case StatusEnum.Sented:
                    return new StatusSented();
                default:
                    throw new Exception("Для статуса " + statusEnum.ToString() + " не реализован класс");
            }
        }
    }
}
