using dotnet_etcd;
using Etcdserverpb;
using Newtonsoft.Json;
using System.Threading.Tasks;
using static  System.Console;

namespace MediatrWeb.Options
{
    public class Etcd_Client
    {
        //private string hostList = @"http://localhost:2380, http://localhost:2379";
        private readonly EtcdClient etcdClient = null;

        /// <summary>
        /// Json with Member List
        /// </summary>
        public string JsonMemberList { get; set; }


        public Etcd_Client(string hostList)
        {
            etcdClient = new EtcdClient(connectionString: hostList);

        }

        #region Cluster Operations




        public async Task<string> ListAllMembersInCluster()
        {
            MemberListRequest request = new MemberListRequest();
            etcdClient.MemberList(request);

            // Sync
            //MemberListResponse res = etcdClient.MemberList(request);

            // Async
            MemberListResponse res = await etcdClient.MemberListAsync(request);

            JsonMemberList = JsonConvert.SerializeObject(res);



            // Do something with response
            //foreach (var member in res.Members)
            //{
            //    WriteLine($"member.ID: {member.ID} - member.Name: {member.Name} - member.PeerURLs :{member.PeerURLs} - member.ClientURLs: { member.ClientURLs}");
            //}

            return JsonMemberList;
        }


        /* TODO:
         
        Cluster Operations
        Add a member into the cluster
         MemberAddRequest request = new MemberAddRequest();
         request.PeerURLs.Add("http://example.com:2380");
         request.PeerURLs.Add("http://10.0.0.1:2380");
         MemberAddResponse res = etcdClient.MemberAdd(request);

         // Async
         MemberAddResponse res = await etcdClient.MemberAddAsync(request);

         // Do something with response
        Remove an existing member from the cluster
        MemberRemoveRequest request = new MemberRemoveRequest
        {
            // ID of member to be removed
            ID = 651748107021
        };
        MemberRemoveResponse res = etcdClient.MemberRemove(request);

        // Async
        MemberRemoveResponse res = await etcdClient.MemberRemoveAsync(request);

        // Do something with response
        Update the member configuration
        MemberUpdateRequest request = new MemberUpdateRequest
        {
            // ID of member to be updated
            ID = 651748107021
        };
        request.PeerURLs.Add("http://10.0.0.1:2380");
        MemberUpdateResponse res = etcdClient.MemberUpdate(request);

        // Async
        MemberUpdateResponse res = await etcdClient.MemberUpdateAsync(request);

        // Do something with response
        List all the members in the cluster
        MemberListRequest request = new MemberListRequest();
        etcdClient.MemberList(request);
        MemberListResponse res = etcdClient.MemberList(request);

        // Async
        MemberListResponse res = await etcdClient.MemberListAsync(request);

        // Do something with response
        foreach(var member in res.Members)
        {
            Console.WriteLine($"{member.ID} - {member.Name} - {member.PeerURLs}");
        } 

        */



        #endregion








    }
}
