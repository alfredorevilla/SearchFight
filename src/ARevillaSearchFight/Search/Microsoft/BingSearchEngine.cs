using ARevillaSearchFight.Engines.Microsoft.Models;
using ARevillaSearchFight.Models;
using ARevillaSearchFight.Search;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace ARevillaSearchFight.Engines.Microsoft
{
    [SearchEngineMetadata("Bing")]
    public class BingSearchEngine : ISearchEngine
    {
        private const string api_base_address = "https://api.cognitive.microsoft.com/";
        private const string api_key = "c907d7f9d86a4c92ae6aa5300b958e2e";
        private const string api_key_header = "Ocp-Apim-Subscription-Key";

        private HttpClient _httpClient;

        public BingSearchEngine() : this(new HttpClient())
        {
        }

        public BingSearchEngine(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            this._httpClient.BaseAddress = new Uri(api_base_address);
            this._httpClient.DefaultRequestHeaders.Add(api_key_header, api_key);
        }

        public BingSearchEngine(HttpMessageHandler handler) : this(new HttpClient(handler))
        {
        }

        //  todo: async support
        public int GetSearchTotalCount(string term)
        {
            var parameters = new BingWebSearchParameters
            {
                Query = term,
                Count = 0,
            };
            var uri = new Uri(this._httpClient.BaseAddress, parameters.ToUri());
            var result = this._httpClient.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<BingSearchResponseModel>(result.Content.ReadAsStringAsync().Result);
                return response.WebPages.TotalEstimatedMatches;
            }
            throw new BingSearchEngineException(result.ReasonPhrase);
        }
        
    }
}