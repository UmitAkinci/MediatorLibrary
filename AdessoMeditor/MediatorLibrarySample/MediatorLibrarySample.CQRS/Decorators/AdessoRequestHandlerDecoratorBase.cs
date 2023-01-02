using MediatorLibrarySample.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrarySample.CQRS.Decorators
{
    public abstract class AdessoRequestHandlerDecoratorBase<TRequest, TResponse> : IAdessoRequestHandler<TRequest, TResponse>
        where TRequest : IAdessoRequest<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
