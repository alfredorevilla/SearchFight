using ARevillaSearchFight.Engines.Google.Models;
using ARevillaSearchFight.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ARevillaSearchFight.Engines.Google
{
    [SearchEngineMetadata("Google")]
    public class GoogleCustomSearchEngine : ISearchEngine
    {
        HttpClient _httpClient;

        static readonly Uri api_base_uri = new Uri("https://www.googleapis.com/", UriKind.Absolute);
        const string search_endpoint = "v1";
        const string api_key = "AIzaSyBqfvaLisPcGEzY9-6gpjW8YR0MWlUNNVY";
        const string api_cx = "003827787859592739507:hinvuv0dxxy";


        /// <summary>
        /// Todo: May add ctor to inject <see cref="HttpClient"/>
        /// </summary>
        public GoogleCustomSearchEngine()
        {
            _httpClient = new HttpClient();

        }

        static Uri GetSearchTotalCountApiRelativeUri(string q)
        {
            //  google likes + symbol instead of space so why would not we?
            q = q.Replace(" ", "+");
            return new Uri($"customsearch/v1?key={api_key}&cx={api_cx}&q={q}&num=1", UriKind.Relative);
        }

        public int GetSearchTotalCount(string term)
        {
            try
            {
                var uri = new Uri(api_base_uri, GetSearchTotalCountApiRelativeUri(term));
                var response = this._httpClient.GetStringAsync(uri).Result;
                var model = JsonConvert.DeserializeObject<GoogleCustomSearchResponse>(response);
                return model.SearchInformation.TotalResults;
            }
            catch (Exception e)
            {
                throw new GoogleCustomSearchException(e.Message);
            }
        }

        public SearchResults Search(string term, int offset, int maxResults)
        {
            throw new NotImplementedException();
        }
    }
}
