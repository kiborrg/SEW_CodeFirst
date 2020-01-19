using SEW_CodeFirst.Models.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SEW_CodeFirst.Models.DTO.SearchEngines
{
    public class Yandex : WebSearch
    {
        public Yandex(MainViewModel model, SearchEngine engine) : base(model, engine)
        { }

        public async override Task<List<SearchResult>> GetResultsAsync()
        {
            await Model.Context.Logs.AddAsync(new Log
            {
                EngineId = Engine.EngineId,
                DateStamp = DateTime.Now.ToString(),
                Message = $"{Engine.Name} начал собирать данные"
            });

            string Url = $@"{Engine.LinkAPI}l10n=en&user={Engine.User}&key={Engine.KeyAPI}&query={Model.SearchVal.Replace(" ", "+")}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            XmlReader xmlReader = XmlReader.Create(response.GetResponseStream());
            XDocument xmlResponse = await Task.Run(() => XDocument.Load(xmlReader));

            List<SearchResult> results = new List<SearchResult>();

            var groupQuery = from gr in xmlResponse.Elements()
                             .Elements("response")
                             .Elements("results")
                             .Elements("grouping")
                             .Elements("group")
                             select gr;

            for (int i = 0; i < groupQuery.Count(); i++)
            {
                await Model.Context.Logs.AddAsync(new Log
                {
                    EngineId = Engine.EngineId,
                    DateStamp = DateTime.Now.ToString(),
                    Message = $"{Engine.Name} получает данные"
                });
                await Task.Run(() => results.Add(new SearchResult
                {
                    Title = GetValue(groupQuery.ElementAt(i), "title"),
                    Link = GetValue(groupQuery.ElementAt(i), "url"),
                    Snippet = GetValue(groupQuery.ElementAt(i), "headline"),
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

            return results;
        }

        public override List<SearchResult> GetResults()
        {
            Model.Context.Logs.Add(new Log
            {
                EngineId = Engine.EngineId,
                DateStamp = DateTime.Now.ToString(),
                Message = $"{Engine.Name} начал собирать данные"
            });

            string Url = $@"{Engine.LinkAPI}l10n=en&user={Engine.User}&key={Engine.KeyAPI}&query={Model.SearchVal.Replace(" ", "+")}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            XmlReader xmlReader = XmlReader.Create(response.GetResponseStream());
            XDocument xmlResponse = XDocument.Load(xmlReader);

            List<SearchResult> results = new List<SearchResult>();

            var groupQuery = from gr in xmlResponse.Elements()
                             .Elements("response")
                             .Elements("results")
                             .Elements("grouping")
                             .Elements("group")
                             select gr;

            for (int i = 0; i < groupQuery.Count(); i++)
            {
                Model.Context.Logs.Add(new Log
                {
                    EngineId = Engine.EngineId,
                    DateStamp = DateTime.Now.ToString(),
                    Message = $"{Engine.Name} получает данные"
                });
                results.Add(new SearchResult
                {
                    Title = GetValue(groupQuery.ElementAt(i), "title"),
                    Link = GetValue(groupQuery.ElementAt(i), "url"),
                    Snippet = GetValue(groupQuery.ElementAt(i), "headline"),
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

            return results;
        }

        public static string GetValue(XElement group, string name)
        {
            try
            {
                return group.Element("doc").Element(name).Value;
            }
            catch
            {
                return String.Empty;
            }
        }
    }
}
