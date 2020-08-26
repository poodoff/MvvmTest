using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Repositories
{
    public class ChartRepositoryImpl : IChartRepository
    {
        protected const string MethodName = "chart.getTopArtists";

        public async Task<IReadOnlyList<SimpleArtistModel>> GetTopAtists(int limit = 100)
        {
            var client = new HttpClient();
            var url = $"{App.MainUrl}?method={MethodName}&format=json&api_key={App.ApiKey}&limit={limit}";
            var response = await client.GetAsync(url);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<TopArtistsModel>(content);
                return model?.Artists?.Artist ?? new List<SimpleArtistModel>();
            }

            return new List<SimpleArtistModel>();
        }
    }
}
