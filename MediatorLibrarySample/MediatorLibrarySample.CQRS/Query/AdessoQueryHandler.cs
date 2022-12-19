using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrarySample.CQRS.Queries
{
    public abstract class AdessoQueryHandler<TRequest, TResponse> : IAdessoQueryHandler<TRequest, TResponse>
        where TRequest : IAdessoQuery<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
