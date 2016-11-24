using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrikam
{
    public class Bookings
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "createdAt")]
        public string createdAt { get; set; }

        [JsonProperty(PropertyName = "updatedAt")]
        public string updatedAt { get; set; }

        [JsonProperty(PropertyName = "version")]
        public string version { get; set; }

        [JsonProperty(PropertyName = "deleted")]
        public bool deleted { get; set; }

        [JsonProperty(PropertyName = "CustomerName")]
        public string CustomerName { get; set; }

        [JsonProperty(PropertyName = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "Time")]
        public string Time { get; set; }

        [JsonProperty(PropertyName = "Date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "Persons")]
        public string Persons { get; set; }
    }
}
