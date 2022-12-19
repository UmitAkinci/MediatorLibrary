using System.Reflection;
using MediatorLibrarySample.CQRS.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorLibrarySample.CQRS.Meditor
{
    public class AdessoMediator : IAdessoMediator
    {
        private readonly IServiceProvider _serviceProvider;
        public AdessoMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IAdessoRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            Type handlerType = typeof(IAdessoRequestHandler<,>)
                .MakeGenericType(request.GetType(), typeof(TResponse));

            dynamic handler = _serviceProvider.GetRequiredService(handlerType);
            if (handler is null)
            {
                throw new ArgumentNullException("Handler creation error!!");
            }
            return await handler.Handle((dynamic)request, cancellationToken);
        }
    }
}
