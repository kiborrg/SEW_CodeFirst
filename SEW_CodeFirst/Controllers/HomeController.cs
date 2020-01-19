using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SEW_CodeFirst.Models.DTO;
using SEW_CodeFirst.Models.Repository;
using SEW_CodeFirst.Models.Services;
using SEW_CodeFirst.Models.UI;

namespace SEW_CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        SearchContext SearchContext;
        ISearchService SearchService;
        public HomeController(SearchContext searchContext, ISearchService searchService)
        {
            SearchContext = searchContext;
            SearchService = searchService;

            if (SearchContext.Engines.Count() == 0)
            {
                try
                {
                    SearchEnginesData.Initialize(SearchContext);
                }
                catch (Exception ex)
                {
                    SearchContext.Logs.AddAsync(new Log
                    {
                        EngineId = 0,
                        DateStamp = DateTime.Now.ToString(),
                        Message = $"Initialization data failure. Message: {ex.Message}"
                    });
                }
            }
        }

        public IActionResult Index(string searchVal)
        {
            if (searchVal != String.Empty && searchVal != null)
            {
                MainViewModel model = new MainViewModel()
                {
                    SearchVal = searchVal,
                    IsDBSearch = false,
                    Context = SearchContext
                };

                return View(SearchService.GetResults(model));
            }
            else
                return View();
        }

        public IActionResult DbSearch(string searchVal)
        {
            if (searchVal != String.Empty && searchVal != null)
            {
                MainViewModel model = new MainViewModel()
                {
                    SearchVal = searchVal,
                    IsDBSearch = true,
                    Context = SearchContext
                };

                return View(SearchService.GetResults(model));
            }
            else
                return View();
        }
    }
}
