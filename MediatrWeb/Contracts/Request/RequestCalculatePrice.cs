using MediatR;
using MediatrWeb.Contracts.Response;
using Newtonsoft.Json;

namespace MediatrWeb.Contracts.Request
{
    public class RequestCalculatePrice :  IRequest<ResponseCalculatePrice>
    {
        /// <summary>
        /// Size
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }

        /// <summary>
        /// Size describe
        /// </summary>
        [JsonProperty(PropertyName = "describe")]
        public string Describe { get; set; }
    }
}
