using Microsoft.EntityFrameworkCore;
using SEW_CodeFirst.Models.DTO;
using System;
using System.Linq;

namespace SEW_CodeFirst.Models.Repository
{
    public class SearchEnginesData
    {
        public static void Initialize(SearchContext context)
        {
            if (!context.Engines.Any())
            {
                context.Engines.AddRange(
                    new SearchEngine
                    {
                        Id = 1,
                        EngineId = (int)EnginesEnum.Google,
                        Name = "Google",
                        MainLink = "https://www.google.com/",
                        LinkAPI = "https://www.googleapis.com/customsearch/v1?",
                        KeyAPI = "AIzaSyCC2ueoW5QchdnuJjCt8u4TMCo7PnnJRYs",
                        CX = "000739764329397305596:8uyrijdigzp",
                        User = ""
                    },
                    new SearchEngine
                    {
                        Id = 2,
                        EngineId = (int)EnginesEnum.Yandex,
                        Name = "Yandex",
                        MainLink = "https://yandex.ru/",
                        LinkAPI = "https://yandex.com/search/xml?",
                        KeyAPI = "03.612216971:c3002d2de39c64d43b9a7c9cc6a350f0",
                        CX = "",
                        User = "kib-orrg"
                    },
                    new SearchEngine
                    {
                        Id = 3,
                        EngineId = (int)EnginesEnum.Bing,
                        Name = "Bing",
                        MainLink = "https://www.bing.com/",
                        LinkAPI = "https://api.cognitive.microsoft.com/bing/v5.0/search?",
                        KeyAPI = "ad460a09e900442b852bdb342c1b731c",
                        CX = "",
                        User = ""
                    }
                );
                try
                {
                    context.Database.OpenConnection();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.engines ON;");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.engines OFF;");
                }
                catch (Exception ex)
                {
                    context.Logs.AddAsync(new Log
                    {
                        EngineId = 0,
                        DateStamp = DateTime.Now.ToString(),
                        Message = $"Error writing data. Message: {ex.Message}"
                    });
                }
            }
        }
    }
}
