using MediatR;
using MediatrWeb.Contracts.Response;
using Newtonsoft.Json;
using System;

namespace MediatrWeb.Contracts.Request
{
    public class MyPipeRequest : IRequest<MyPipeResponse>
    {
        /// <summary>
        /// Name of method to invoke
        /// </summary>
        [JsonProperty(PropertyName = "method")]
        public string MethodName { get; set; }
        /// <summary>
        /// Metadata to process
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public dynamic MetaData { get; set; }


    }
}
