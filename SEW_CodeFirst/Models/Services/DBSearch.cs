using SEW_CodeFirst.Models.DTO;
using SEW_CodeFirst.Models.UI;
using System.Collections.Generic;
using System.Linq;

namespace SEW_CodeFirst.Models.Services
{
    public class DBSearch : ISearch
    {
        public List<SearchResult> GetResults(MainViewModel model)
        {
            List<SearchResult> results = model.Context.Results.Where(r => r.Link.Contains(model.SearchVal) || r.Title.Contains(model.SearchVal) || r.Snippet.Contains(model.SearchVal)).ToList();
            if (results.Count == 0)
                results.Add(new SearchResult
                {
                    Title = "Sorry, search results in database is not found. \nSearch it on Web",
                    Link = "Index"
                });
            return results;
        }
    }
}
