using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Results
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("degree")]
        public string Degree { get; set; }

        [JsonProperty("min")]
        public string Min { get; set; }

        [JsonProperty("max")]
        public string Max { get; set; }

        [JsonProperty("night")]
        public string Night { get; set; }

        [JsonProperty("humidity")]
        public string Humidity { get; set; }
    }

    public class WeatherModel
    {
        [JsonProperty("result")]
        public List<Results> Results { get; set; }
    }
}
