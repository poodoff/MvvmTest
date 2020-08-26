using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api.Models
{
    public class TopArtistsModel
    {
        public InnerArtistsModel Artists { get; set; }
    }

    public class InnerArtistsModel
    {
        public List<SimpleArtistModel> Artist { get; set; }
        [JsonProperty("@attr")]
        public RequestPageAttr Attrs { get; set; }
    }
}
