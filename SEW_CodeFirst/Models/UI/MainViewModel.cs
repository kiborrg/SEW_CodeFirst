using SEW_CodeFirst.Models.Repository;

namespace SEW_CodeFirst.Models.UI
{
    public class MainViewModel
    {
        public string SearchVal { get; set; }
        public bool IsDBSearch { get; set; }
        public SearchContext Context { get; set; }
    }
}
