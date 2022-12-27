using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrarySample.CQRS.Commands
{
    public abstract class AdessoCommandHandler<TRequest, TResponse> : IAdessoCommandHandler<TRequest, TResponse>
        where TRequest : IAdessoCommand<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
