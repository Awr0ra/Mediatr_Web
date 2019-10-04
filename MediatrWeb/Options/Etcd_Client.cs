using dotnet_etcd;
using Etcdserverpb;
using static  System.Console;

namespace MediatrWeb.Options
{
    public class Etcd_Client
    {
        private string hostList = @"http://localhost:2380, http://localhost:2379";
        private readonly EtcdClient etcdClient = null;

        public Etcd_Client()
        {
            etcdClient = new EtcdClient(connectionString: hostList);

        }

        public async void ListAllMembersInCluster()
        {
            MemberListRequest request = new MemberListRequest();
            etcdClient.MemberList(request);

            // Sync
            //MemberListResponse res = etcdClient.MemberList(request);

            // Async
            MemberListResponse res = await etcdClient.MemberListAsync(request);

            // Do something with response
            foreach (var member in res.Members)
            {
                WriteLine($"{member.ID} - {member.Name} - {member.PeerURLs}");
            }
        }

}
}
