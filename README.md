#Title
SEW is a web-application to search information based on the Code First method and implementation of the Factory pattern. 
SEW provides users with the ability to search for information on the Web or in their own database of previously found sources.

#Structure
The project includes:
- **HomeController**: Main controller;
- **SearchContext**: Database context;
- **SearchEnginesData**: Input data for the organization of the work of search engines;
- 3 tables for organizing work with the database:
  - **SearchEngine**: description of the structure of the search engine;
  - **SearchResult**: description of the structure of the search result;
  - **Log**: a table for logging errors;
- **MainViewModel**: class for transferring input data and database context from views to services;
- Interfaces (**ISearch**, **IWebSearch**) and services (**DBSearch**, **SearchService**): for organizing searching in the database and implementing the factory method for Web searches;
- Abstract class **WebSearch**: to declare the abstract method *GetResults* to search for information and initialize the method *InsertResults* to write the found data to the database;
- 3 child classes for the class **WebSearch** (**Bing**, **Google**, **Yandex**), which implements the algorithm for searching information in the same search engines;
- 2 views (**DbSearch**, **Index**).

# Search implementation
Search on Google, Yandex and Bing are using the API. A link was collected, including an API link, an API key and additional data.
All APIs are available after registering and setting the basic parameters for getting keys.
Data is searched asynchronously. The code will show the synchronous variations of data retrieval methods.

The basis for all the search engines described is creating a request and receiving a response.

var request = WebRequest.Create (url);
HttpWebResponse response = (HttpWebResponse)request.GetResponse();

## Google CustomSearch
It is possible to access the GoogleCustomSearch API through the package that is plugged into NuGet or by the link:
https://www.googleapis.com/customsearch/v1?key=**YOUR_API_KEY**&cx=**YOUR_CX_KEY**&q=**SEARCH_QUERY**,
where **YOUR_API_KEY** is the key issued during registration of the search engine,
**YOUR_CX_KEY** - ID of a registered search engine,
**SEARCH_QUERY** is the search string.

The response comes in the form of a JSON object. Its structure is available at https://developers.google.com/custom-search/v1/cse/list.
Search results are stored as a list in the **item** property. Search results can be obtained using foreach:
foreach (var item in jsonData.items)
{
  results.Add (new SearchResult
  {
    Title = item.title,
    Link = item.link,
    Snippet = item.snippet,
    EngineId = Engine.EngineId,
    Query = Model.SearchVal
  });
},
where jsonData is a dynamic JSON object

## Yandex.XML
It is possible to access the Yandex.XML API by using the POST or GET method link. For the POST method, you need to generate a request in XML format of a certain structure. For the GET method, only a link string is required.
The project uses the GET method. The link is formed as follows:
https://yandex.com/search/xml?l10n=en&user=**USER_NAME**&key=**YOUR_API_KEY**&query=**SEARCH_QUERY**,
where **USER_NAME** is the name of the user who received the key,
**YOUR_API_KEY** - issued key,
**SEARCH_QUERY** is the search string.
A more detailed structure can be studied on the official website.
The answer comes in XML format. When registering a key for a search engine (https://xml.yandex.ru/), the response structure will be shown.
After receiving the XML document with the search results, it is required to parse it.
Search results can be obtained using the query below. The purpose of the request: to find the tag *group* - there are the search results.
var groupQuery = from gr in xmlResponse.Elements()
                  .Elements("response")
                  .Elements("results")
                  .Elements("grouping")
                  .Elements("group")
                  select gr;

Each of the results also has its own structure, which is enclosed in the tag *doc*. Therefore, after the query is completed, it is required to organize a cycle on objects from the query result and receive each parameter individually:
for (int i = 0; i < groupQuery.Count(); i ++)
{
  results.Add(new SearchResult
  {
    Title = GetValue(groupQuery.ElementAt(i), "title"),
    Link = GetValue(groupQuery.ElementAt(i), "url"),
    Snippet = GetValue(groupQuery.ElementAt(i), "headline"),
    EngineId = Engine.EngineId,
    Query = Model.SearchVal
  }));
},
Where
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

## Bing
The Bing Search API is provided upon registration with Microsoft Azure. Trial version is available for use during the week.
You can access the Bing Search API using the link:
https://api.cognitive.microsoft.com/bing/v5.0/search?q=**SEARCH_QUERY**,
where **SEARCH_QUERY** is the search string.
Unlike Google and Yandex, the Bing Search API key is inserted into the request header
request.Headers["Ocp-Apim-Subscription-Key"] = Engine.KeyAPI;

The answer comes in the form of a JSON object. Its structure is presented at https://docs.microsoft.com/en-us/azure/cognitive-services/bing-web-search/quickstarts/csharp.
Search results are stored as a list in the **value** property.
Search results can be obtained using foreach:
foreach(var item in jsonData.webPages.value)
{
  results.Add(new SearchResult
  {
    Title = item.name,
    Link = item.url,
    Snippet = item.snippet,
    EngineId = Engine.EngineId,
    Query = Model.SearchVal
  });
},
where jsonData is a dynamic JSON object

# Adding a new search engine
There are 2 algorithms for adding a new search engine:
1. Adding a new key for one of the described search engines - each key has its own settings for filtering results, grouping them or other settings;
2. Adding an indescribable search engine - the search engine is not described, you need to write an algorithm for obtaining and processing search results.

## Adding a new key for one of the described search engines
To apply the new search settings for the described search engine, you need to insert an entry in the database into the table ** Engines **

## Adding an indescribable search engine
To implement a search for a previously undescribed system, you need:
1. Insert a record in the database into the table **Engines**;
2. Add a new **EngineId** to EnginesEnum (required to handle switch / case when implementing the factory);
3. Create a class that will inherit the abstract class **WebSearch** and override the methods **GetResults** and **GetResultsAsync** - search algorithms in it
4. In the **SearchService** service, in the **GetWebResults** function add a case to call the class with the algorithm for searching and processing the results.

# Deployment and launch of the project
Project rollout is only available in Visual Studio.

Dockerfile is present but not verified due to lack of time.

# Unit tests
Unit tests are absent due to lack of time for their implementation.
