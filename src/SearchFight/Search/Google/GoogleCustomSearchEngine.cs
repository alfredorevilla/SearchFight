using SearchFight.Engines.Google.Models;
using SearchFight.Search;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchFight.Engines.Google
{
    [SearchEngineMetadata("Google")]
    public class GoogleCustomSearchEngine : ISearchEngine
    {
        private const string api_cx = "003827787859592739507:hinvuv0dxxy";
        private const string api_key = "AIzaSyBqfvaLisPcGEzY9-6gpjW8YR0MWlUNNVY";
        private const string search_endpoint = "v1";
        private static readonly Uri api_base_uri = new Uri("https://www.googleapis.com/", UriKind.Absolute);
        private HttpClient _httpClient;

        /// <summary>
        /// Todo: May add ctor to inject <see cref="HttpClient"/>
        /// </summary>
        public GoogleCustomSearchEngine()
        {
            _httpClient = new HttpClient();
        }

        public async Task<long> GetSearchTotalCountAsync(string term)
        {
            var uri = new Uri(api_base_uri, GetSearchTotalCountApiRelativeUri(term));
            var result = await this._httpClient.GetAsync(uri);
            if (result.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<GoogleCustomSearchResponse>(await result.Content.ReadAsStringAsync());
                return response.SearchInformation.TotalResults;
            }
            throw new GoogleCustomSearchException(result.ReasonPhrase);
        }

        private static Uri GetSearchTotalCountApiRelativeUri(string q)
        {
            //  google likes + symbol instead of space so why would not we?
            q = q.Replace(" ", "+");
            return new Uri($"customsearch/v1?key={api_key}&cx={api_cx}&q={q}&num=1", UriKind.Relative);
        }
    }
}