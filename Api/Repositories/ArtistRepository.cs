using System;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Models;
using Api.Models.Artist;
using MvvmCross.Logging;

namespace Api.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        const string MethodName = "artist.getInfo";
        private HttpClient _httpClient;
        private IMvxLog _logger;

        public ArtistRepository(HttpClient httpClient, MvvmCross.Logging.IMvxLog logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ArtistModel> GetInfo(string artistUid)
        {
            try
            {
                var url = $"{App.MainUrl}?method={MethodName}&format=json&api_key={App.ApiKey}&mbid={artistUid}";
                var response = await _httpClient.GetAsync(url);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var model = Newtonsoft.Json.JsonConvert.DeserializeObject<ArtistResponseModel>(content);
                    return model?.Artist;
                }
            }
            catch (Exception ex)
            {
                _logger.ErrorException("Get artist info exception: ", ex);
            }

            return null;
        }
    }
}
