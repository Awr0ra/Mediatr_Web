using Newtonsoft.Json;
using System;

namespace MediatrWeb.Contracts.Response
{
    public class MyPipeResponse
    {
        [JsonProperty(PropertyName = "requestId")]
        public Guid RequestId { get; set; }

        [JsonProperty(PropertyName = "responseMy")]
        public dynamic ResponseMy { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
    }
}
