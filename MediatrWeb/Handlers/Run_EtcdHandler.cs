using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrWeb.Configurations;
using MediatrWeb.Contracts.Request;
using MediatrWeb.Contracts.Response;
using MediatrWeb.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace MediatrWeb.Handlers
{
    public class Run_EtcdHandler : IRequestHandler<RequestEtcd, ResponseEtcd>
    {
        private readonly string _etcdMembersUri;
        private readonly string _etcdLogin;
        private readonly string _etcdPassword;

        public Run_EtcdHandler(IOptions<GeneralConfig> appSettings)
        {
            _etcdLogin = appSettings.Value.EtcdLogin;
            _etcdPassword = appSettings.Value.EtcdPassword;
            _etcdMembersUri = appSettings.Value.EtcdMembersUri;

        }

        public async Task<ResponseEtcd> Handle(RequestEtcd request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_etcdMembersUri))
            {
                // todo: return error
            }

            Etcd_Client etcd = new Etcd_Client(_etcdMembersUri);
            string membersList = await etcd.ListAllMembersInCluster();

            return new ResponseEtcd()
            {
                IdRequest = request.IdRequest,
                ResponseDT = DateTime.UtcNow,
                EtcdMemberList = etcd.JsonMemberList
            };
        }
    }
}
