using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatrWeb.Contracts.Response
{
    public class ResponseEtcd
    {
        /// <summary>
        /// GUID Request ID (from request)
        /// </summary>
        [JsonProperty(PropertyName = "idRequest")]
        public Guid IdRequest { get; set; }

        /// <summary>
        /// Response DateTime 
        /// </summary>
        [JsonProperty(PropertyName = "dtResponse")]
        public DateTime ResponseDT { get; set; }

        /// <summary>
        /// ETCD Member List 
        /// </summary>
        [JsonProperty(PropertyName = "etcdMemberList")]
        public string EtcdMemberList { get; set; }
    }
}
