using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrWeb.Contracts.Request;
using MediatrWeb.Contracts.Response;
using Newtonsoft.Json.Linq;

namespace MediatrWeb.Handlers
{
    public class MyRequestHandler : IRequestHandler<MyPipeRequest, MyPipeResponse>
    {
        private readonly IMediator _mediator;
        private readonly MethodInfo _toObjMethod = typeof(JToken).GetMethod("ToObject", new Type[] { });

        private Dictionary<string, Type> _handlerRequestTypes;


        public MyRequestHandler(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _handlerRequestTypes = GetHandlerMethods();
        }

        public async Task<MyPipeResponse> Handle(MyPipeRequest request, CancellationToken cancellationToken)
        {
            var method = request.MethodName;
            var requestData = request.MetaData;
            var error = "Ok";

            //DefaultResponse result = new DefaultResponse();
            dynamic result = null;
            Type requestType;


            if (_handlerRequestTypes.TryGetValue(method, out requestType))
            {
                dynamic req = null;

                try
                {
                    req = _toObjMethod.MakeGenericMethod(requestType).Invoke(requestData, new object[] { });

                    //(req as DefaultRequest).InjectGuid(request.Guid);

                    result = await _mediator.Send(req);
                }
                catch (Exception ex)
                {
                    error = $"Error: {ex.Message}.";
                }
            }
            else
            {
                error = $"Error: Method '{method}' is not found.";
            }

            return new MyPipeResponse()
            {
                Error = error,
                //RequestId = request.RequestId,
                ResponseMy = result
            };
        }


        /// <summary>
        /// Handler's dictionary. method - type TRequest
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, Type> GetHandlerMethods()
        {
            var handlers = typeof(Startup).Assembly.GetTypes()
                 .Where(t => t.GetInterfaces().Any(x => x.IsGenericType
                && x.Name == "IRequestHandler`2"
                 )
                 && t.Name.EndsWith("Handler"))
                 .ToList();

            var assembled = handlers
             .Select(t => new
             {
                 Key = t.Name.Substring(0, t.Name.IndexOf("Handler")),
                 Type = t.GetInterfaces()
                 .Where(x => x.IsGenericType && x.Name == "IRequestHandler`2")
                 .First()
                 .GetGenericArguments()
                 .First()
             });

            return assembled.ToDictionary(kvp => kvp.Key, kvp => kvp.Type);

        }


    }
}
