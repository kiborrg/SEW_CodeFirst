using Newtonsoft.Json;
using SEW_CodeFirst.Models.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SEW_CodeFirst.Models.DTO.SearchEngines
{
    public class Bing : WebSearch
    {
        public Bing(MainViewModel model, SearchEngine engine) : base(model, engine)
        { }

        public async override Task<List<SearchResult>> GetResultsAsync()
        {
            await Model.Context.Logs.AddAsync(new Log
            {
                EngineId = Engine.EngineId,
                DateStamp = DateTime.Now.ToString(),
                Message = $"{Engine.Name} начал собирать данные"
            });

            string url = $@"{Engine.LinkAPI}q={Model.SearchVal.Replace(" ", "+")}";

            WebRequest request = HttpWebRequest.Create(url);
            request.Headers["Ocp-Apim-Subscription-Key"] = Engine.KeyAPI;
            HttpWebResponse response = await Task.Run(() => (HttpWebResponse)request.GetResponseAsync().Result);
            string json = await new StreamReader(response.GetResponseStream()).ReadToEndAsync();

            dynamic jsonData = JsonConvert.DeserializeObject(json);

            List<SearchResult> results = new List<SearchResult>();


            foreach (var item in jsonData.webPages.value)
            {
                await Model.Context.Logs.AddAsync(new Log
                {
                    EngineId = Engine.EngineId,
                    DateStamp = DateTime.Now.ToString(),
                    Message = $"{Engine.Name} получает данные"
                });
                await Task.Run(() => results.Add(new SearchResult
                {
                    Title = item.name,
                    Link = item.url,
                    Snippet = item.snippet,
                    EngineId = Engine.EngineId,
                    Query = Model.SearchVal
                }));
            }

            await Model.Context.Logs.AddAsync(new Log
            {
                EngineId = Engine.EngineId,
                DateStamp = DateTime.Now.ToString(),
                Message = $"{Engine.Name} записывает данные"
            });
            InsertResults(results);

            return results.ToList();
        }

        public override List<SearchResult> GetResults()
        {
            Model.Context.Logs.Add(new Log
            {
                EngineId = Engine.EngineId,
                DateStamp = DateTime.Now.ToString(),
                Message = $"{Engine.Name} начал собирать данные"
            });

            string url = $@"{Engine.LinkAPI}q={Model.SearchVal.Replace(" ", "+")}";

            WebRequest request = HttpWebRequest.Create(url);
            request.Headers["Ocp-Apim-Subscription-Key"] = Engine.KeyAPI;
            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

            dynamic jsonData = JsonConvert.DeserializeObject(json);

            List<SearchResult> results = new List<SearchResult>();


            foreach (var item in jsonData.webPages.value)
            {
                Model.Context.Logs.Add(new Log
                {
                    EngineId = Engine.EngineId,
                    DateStamp = DateTime.Now.ToString(),
                    Message = $"{Engine.Name} получает данные"
                });
                results.Add(new SearchResult
                {
                    Title = item.name,
                    Link = item.url,
                    Snippet = item.snippet,
                    EngineId = Engine.EngineId,
                    Query = Model.SearchVal
                });
            }

            Model.Context.Logs.Add(new Log
            {
                EngineId = Engine.EngineId,
                DateStamp = DateTime.Now.ToString(),
                Message = $"{Engine.Name} записывает данные"
            });
            InsertResults(results);

            return results.ToList();
        }
    }
}
