using MediatR;
using MediatrWeb.Contracts.Request;
using MediatrWeb.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrWeb.Handlers
{
    public class Get_CalculateHandler : IRequestHandler<RequestCalculatePrice, ResponseCalculatePrice>
    {
        
        public Get_CalculateHandler()
        {
            int i = 0;
        }

        public async Task<ResponseCalculatePrice> Handle(RequestCalculatePrice request, CancellationToken cancellationToken)
        {
            float price_koeff = 1.005F;


            return new ResponseCalculatePrice() {
                Price = (float)Math.Round(request.Size * price_koeff, 2, MidpointRounding.AwayFromZero),
                Describe = "calculated from - " + request.Describe,
                Size = request.Size

            };

        }
    }
}
