using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api.Models
{
    public class SimpleArtistModel
    {
        [JsonProperty("mbid")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string PlayCount { get; set; }
        public string Listeners { get; set; }
        [JsonProperty("image")]
        public List<ImageModel> Images { get; set; }
    }
}
