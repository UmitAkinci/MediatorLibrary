using MediatorLibrarySample.CQRS.Commands;

namespace MediatorLibrarySample.CQRS.Decorators
{
    public class AdessoCommandHandlerDecorator<TRequest, TResponse> : AdessoRequestHandlerDecoratorBase<TRequest, TResponse>
        where TRequest : IAdessoCommand<TResponse>
    {
        private readonly IAdessoCommandHandler<TRequest, TResponse> _handler;
        public AdessoCommandHandlerDecorator(IAdessoCommandHandler<TRequest, TResponse> handler)
        {
            _handler = handler;
        }
        public async override Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            return await _handler.Handle(request, cancellationToken);
        }
    }
}
