using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatorLibrarySample.CQRS.Commands;
using MediatorLibrarySample.CQRS.Queries;

namespace MediatorLibrarySample.CQRS.Decorators
{
    public class AdessoQueryHandlerDecorator<TRequest, TResponse> : AdessoRequestHandlerDecoratorBase<TRequest, TResponse>
        where TRequest : IAdessoQuery<TResponse>
    {
        private readonly IAdessoQueryHandler<TRequest, TResponse> _handler;
        public AdessoQueryHandlerDecorator(IAdessoQueryHandler<TRequest, TResponse> handler)
        {
            _handler = handler;
        }

        public async override Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            return await _handler.Handle(request, cancellationToken);
        }
    }
}
