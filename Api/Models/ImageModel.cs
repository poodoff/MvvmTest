using System;
using Newtonsoft.Json;

namespace Api.Models
{
    public class ImageModel
    {
        [JsonProperty("#text")]
        public string Url { get; set; }
        public string Size { get; set; }
    }
}
