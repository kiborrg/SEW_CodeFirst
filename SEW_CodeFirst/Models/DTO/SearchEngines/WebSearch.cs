using SEW_CodeFirst.Models.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SEW_CodeFirst.Models.DTO.SearchEngines
{
    public interface IWebSearch
    {
        /// <summary>
        /// Insert finding results in database
        /// </summary>
        /// <param name="results"></param>
        void InsertResults(List<SearchResult> results);
        /// <summary>
        /// Get search results
        /// </summary>
        /// <param name="query">The string to find</param>
        /// <returns>List of found links by request</returns>
        List<SearchResult> GetResults();
        Task<List<SearchResult>> GetResultsAsync();
    }

    public abstract class WebSearch : IWebSearch
    {
        static AutoResetEvent waitHandler = new AutoResetEvent(true);
        public MainViewModel Model { get; set; }
        public SearchEngine Engine { get; set; }

        public WebSearch(MainViewModel model, SearchEngine engine)
        {
            Model = model;
            Engine = engine;
        }

        public void InsertResults(List<SearchResult> results)
        {
            waitHandler.WaitOne();
            List<SearchResult> distinctRes = new List<SearchResult>();

            try
            {
                var records = Model.Context.Results.ToList();
                foreach (SearchResult record in results)
                {
                    var rec = records.Where(r => r.Title == record.Title && r.Link == record.Link && r.Snippet == record.Snippet).ToList();

                    if (rec.Count == 0)
                    {
                        distinctRes.Add(record);
                    }
                }

                Model.Context.Results.AddRange(distinctRes);
                Model.Context.SaveChanges();
            }
            catch(Exception ex)
            {
                Model.Context.Logs.AddAsync(new Log
                {
                    EngineId = Engine.EngineId,
                    DateStamp = DateTime.Now.ToString(),
                    Message = $"Inserting data error. Message: {ex.Message}"
                });
            }
            waitHandler.Set();
        }

        public abstract List<SearchResult> GetResults();
        public abstract Task<List<SearchResult>> GetResultsAsync();
    }
}
