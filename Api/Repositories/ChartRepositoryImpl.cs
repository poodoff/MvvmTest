using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Models;
using Api.Models.Artist;
using MvvmCross.Logging;

namespace Api.Repositories
{
    public class ChartRepositoryImpl : IChartRepository
    {
        protected const string MethodName = "chart.getTopArtists";
        private HttpClient _httpClient;
        private IMvxLog _logger;

        public ChartRepositoryImpl(HttpClient httpClient, MvvmCross.Logging.IMvxLog logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IReadOnlyList<SimpleArtistModel>> GetTopAtists(int limit = 100)
        {
            try
            {
                var url = $"{App.MainUrl}?method={MethodName}&format=json&api_key={App.ApiKey}&limit={limit}";
                var response = await _httpClient.GetAsync(url);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var model = Newtonsoft.Json.JsonConvert.DeserializeObject<TopArtistsModel>(content);
                    return model?.Artists?.Artist ?? new List<SimpleArtistModel>();
                }
            }
            catch (Exception ex)
            {
                _logger.ErrorException("Get top atrists exception: ", ex);
            }

            return new List<SimpleArtistModel>();
        }
    }
}
