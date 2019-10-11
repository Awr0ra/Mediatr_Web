using MediatR;
using MediatrWeb.Contracts.Response;
using Newtonsoft.Json;
using System;

namespace MediatrWeb.Contracts.Request
{
    public class RequestEtcd : IRequest<ResponseEtcd>
    {
        /// <summary>
        /// GUID Request ID
        /// </summary>
        [JsonProperty(PropertyName = "idRequest")]
        public Guid IdRequest { get; set; }
    }
}
