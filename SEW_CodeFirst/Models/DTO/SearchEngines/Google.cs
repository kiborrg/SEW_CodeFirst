using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SEW_CodeFirst.Models.UI;

namespace SEW_CodeFirst.Models.DTO.SearchEngines
{
    public class Google : WebSearch
    {
        public Google(MainViewModel model, SearchEngine engine) : base(model, engine)
        { }

        public async override Task<List<SearchResult>> GetResultsAsync()
        {
            await Model.Context.Logs.AddAsync(new Log
            {
                EngineId = Engine.EngineId,
                DateStamp = DateTime.Now.ToString(),
                Message = $"{Engine.Name} начал собирать данные"
            });

            string url = $@"{Engine.LinkAPI}key={Engine.KeyAPI}&cx={Engine.CX}&q={Model.SearchVal}";
            var request = WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string responceString = await reader.ReadToEndAsync();
            dynamic jsonData = JsonConvert.DeserializeObject(responceString);

            List<SearchResult> results = new List<SearchResult>();

            foreach (var item in jsonData.items)
            {
                await Model.Context.Logs.AddAsync(new Log
                {
                    EngineId = Engine.EngineId,
                    DateStamp = DateTime.Now.ToString(),
                    Message = $"{Engine.Name} получает данные"
                });
                results.Add(new SearchResult
                {
                    Title = item.title,
                    Link = item.link,
                    Snippet = item.snippet,
                    EngineId = Engine.EngineId,
                    Query = Model.SearchVal
                });
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

            var request = WebRequest.Create(Engine.LinkAPI + "key=" + Engine.KeyAPI + "&cx=" + Engine.CX + "&q=" + Model.SearchVal);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string responceString = reader.ReadToEnd();
            dynamic jsonData = JsonConvert.DeserializeObject(responceString);

            List<SearchResult> results = new List<SearchResult>();

            foreach (var item in jsonData.items)
            {
                Model.Context.Logs.Add(new Log
                {
                    EngineId = Engine.EngineId,
                    DateStamp = DateTime.Now.ToString(),
                    Message = $"{Engine.Name} получает данные"
                });
                //if (results.Where(i => String.Equals(i.Title, item.title) && String.Equals(i.Link, item.link) && String.Equals(i.Snippet, item.snippet)).Count() == 0)
                //{
                results.Add(new SearchResult
                    {
                        Title = item.title,
                        Link = item.link,
                        Snippet = item.snippet,
                        EngineId = Engine.EngineId,
                        Query = Model.SearchVal
                    });
                //}
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
