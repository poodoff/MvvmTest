using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api.Models.Artist
{
    public class ArtistModel
    {
        [JsonProperty("mbid")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        [JsonProperty("bio")]
        public ArtistBioModel Bio { get; set; }
        [JsonProperty("image")]
        public List<ImageModel> Images { get; set; }
    }
}
