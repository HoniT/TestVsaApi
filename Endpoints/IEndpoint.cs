using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Endpoints
{
    public interface IEndpoint
    {
        void MapEndpoint(IEndpointRouteBuilder app);
    }
}