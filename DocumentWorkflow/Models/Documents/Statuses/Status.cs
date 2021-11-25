using System;

namespace DocumentWorkflow.Models.Documents.Statuses
{
    public abstract class Status
    {
        protected DocumentTypeEnum typeEnum;
        public abstract StatusEnum Name { get; }
        public abstract string Class { get; }
        public abstract string Text { get; }
        public abstract Status Next();
        public abstract Status Prev();
    }
}