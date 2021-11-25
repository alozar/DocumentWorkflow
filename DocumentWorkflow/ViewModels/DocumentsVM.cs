using DocumentWorkflow.Models;
using DocumentWorkflow.Models.Documents;
using DocumentWorkflow.ViewOptions.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentWorkflow.ViewModels
{
    public class DocumentsVM : ListVM<DocumentsFilter>
    {
        public List<Document> Documents { get; set; }
    }
}
