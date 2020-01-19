using SEW_CodeFirst.Models.DTO;
using SEW_CodeFirst.Models.UI;
using System.Collections.Generic;

namespace SEW_CodeFirst.Models.Services
{
    public interface ISearch
    {
        /// <summary>
        /// Get search results
        /// </summary>
        /// <param name="query">The string to find</param>
        /// <returns>List of found links by request</returns>
        List<SearchResult> GetResults(MainViewModel model);
    }
}
