using SEW_CodeFirst.Models.DTO;
using SEW_CodeFirst.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEW_CodeFirst.Models.UI;
using SEW_CodeFirst.Models.DTO.SearchEngines;

namespace SEW_CodeFirst.Models.Services
{
    public interface ISearchService
    {
        Task<List<SearchResult>> GetWebResults(MainViewModel model);
        List<SearchResult> GetDBResults(MainViewModel model);
        List<SearchResult> GetResults(MainViewModel model);
    }
    public class SearchService : ISearchService
    {
        protected readonly ISearch DBSearch;
        
        public SearchService(ISearch dBSearch)
        {
            DBSearch = dBSearch;
        }

        public async Task<List<SearchResult>> GetWebResults(MainViewModel model)
        {
            List<List<SearchResult>> searchResults = new List<List<SearchResult>>();
            
            List<SearchEngine> engines = model.Context.Engines.ToList();
            Task<List<SearchResult>>[] tasks = new Task<List<SearchResult>>[engines.Count];
            int taskNum = 0;

            try
            {
                foreach (SearchEngine engine in engines)
                {
                    switch (engine.EngineId)
                    {
                        case (int)EnginesEnum.Google:
                            WebSearch GSearch = new Google(model, engine);
                            tasks[taskNum] = Task.Run(() => GSearch.GetResultsAsync());
                            break;
                        case (int)EnginesEnum.Yandex:
                            WebSearch YSearch = new Yandex(model, engine);
                            tasks[taskNum] = Task.Run(() => YSearch.GetResultsAsync());
                            break;
                        case (int)EnginesEnum.Bing:
                            WebSearch BSearch = new Bing(model, engine);
                            tasks[taskNum] = Task.Run(() => BSearch.GetResultsAsync());
                            break;
                        default:
                            return new List<SearchResult>();
                    }
                }
            }
            catch(Exception ex)
            {
                await model.Context.Logs.AddAsync(new Log
                {
                    EngineId = 0,
                    DateStamp = DateTime.Now.ToString(),
                    Message = $"Data search error. Message: {ex.Message}"
                });
            }

            var firstResult = await Task.WhenAny(tasks.Where(t => t != null)).Result;
            await Task.WhenAll(tasks.Where(t => t != null).ToArray());
            return firstResult;
        }

        public List<SearchResult> GetDBResults(MainViewModel model)
        {
            return DBSearch.GetResults(model);
        }

        public List<SearchResult> GetResults(MainViewModel model)
        {
            if (model.IsDBSearch)
                return GetDBResults(model);
            else
                return Task.Run(() => GetWebResults(model)).Result;
        }
    }
}
