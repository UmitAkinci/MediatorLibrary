using MediatorLibrarySample.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrarySample.CQRS.Commands
{
    public interface IAdessoCommandHandler<in TRequest, TResponse> : IAdessoRequestHandler<TRequest, TResponse>
        where TRequest : IAdessoCommand<TResponse>
    {
    }
}
