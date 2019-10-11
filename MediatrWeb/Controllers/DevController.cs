using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatrWeb.Contracts.Request;
using MediatrWeb.Contracts.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MediatrWeb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DevController : Controller
    {
        readonly IMediator _mediator;

        public DevController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<MyPipeResponse> SendCalculate(int size = 111, string describe_size = "size description")
        {
            MyPipeRequest request = new MyPipeRequest();

            request.MethodName = "Get_Calculate";
            request.MetaData = JToken.FromObject(new RequestCalculatePrice()
            {
                Size = size,
                Describe = describe_size + "    :   " + DateTime.UtcNow.ToUniversalTime()
            });
            

            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<MyPipeResponse> RunEtcd()
        {
            MyPipeRequest request = new MyPipeRequest();

            request.MethodName = "Run_Etcd";
            request.MetaData = JToken.FromObject(new RequestEtcd()
            {
                IdRequest = Guid.NewGuid()
            });


            return await _mediator.Send(request);
        }


    }
}