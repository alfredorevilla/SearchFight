using ORevillaSearchFight.Engines.Microsoft.Models;
using ORevillaSearchFight.Search;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ORevillaSearchFight.Engines.Microsoft
{
    [SearchEngineMetadata("Bing")]
    public class BingSearchEngine : ISearchEngine
    {
        private const string api_base_address = "https://api.cognitive.microsoft.com/";
        private const string api_key = "c907d7f9d86a4c92ae6aa5300b958e2e";
        private const string api_key_header = "Ocp-Apim-Subscription-Key";

        private HttpClient _httpClient;

        public BingSearchEngine() : this(new HttpClient() { BaseAddress = new Uri(api_base_address) })
        {
        }

        public BingSearchEngine(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            this._httpClient.DefaultRequestHeaders.Add(api_key_header, api_key);
        }

        public async Task<long> GetSearchTotalCountAsync(string term)
        {
            var parameters = new BingWebSearchParameters
            {
                Query = term,
                Count = 0,
            };
            var uri = new Uri(this._httpClient.BaseAddress, parameters.ToUri());
            var result = await this._httpClient.GetAsync(uri);
            if (result.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<BingSearchResponseModel>(await result.Content.ReadAsStringAsync());
                return response.WebPages.TotalEstimatedMatches;
            }
            throw new BingSearchEngineException(result.ReasonPhrase);
        }
    }
}