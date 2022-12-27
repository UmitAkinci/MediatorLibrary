using System.Reflection;
using MediatorLibrarySample.CQRS.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorLibrarySample.CQRS.Meditor
{
    internal class AdessoMediator : IAdessoMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public AdessoMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IAdessoRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            //Type handlerType = typeof(IAdessoRequestHandler<,>)
            //    .MakeGenericType(request.GetType(), typeof(TResponse));

            //dynamic handler = _serviceProvider.GetRequiredService(handlerType);
            //if (handler is null)
            //{
            //    throw new ArgumentNullException("Handler creation error!!");
            //}
            //return await handler.Handle((dynamic)request, cancellationToken);


            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var requestType = request.GetType();

            dynamic handler = (Activator.CreateInstance(typeof(AdessoRequestHandlerWrapper<,>).MakeGenericType(requestType, typeof(TResponse)))
                                                 ?? throw new InvalidOperationException($"Could not create wrapper type for {requestType}"));

            return handler.Handle(request, _serviceProvider, cancellationToken);
        }
    }


}
