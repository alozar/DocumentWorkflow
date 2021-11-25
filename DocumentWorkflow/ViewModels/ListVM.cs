using DocumentWorkflow.ViewOptions;

namespace DocumentWorkflow.ViewModels
{
    public class ListVM<F> where F : FilterOptions
    {
        public OrderOptions OrderOptions { get; set; }
        public PageOptions PageOptions { get; set; }
        public F FilterOptions { get; set; }
    }
}
