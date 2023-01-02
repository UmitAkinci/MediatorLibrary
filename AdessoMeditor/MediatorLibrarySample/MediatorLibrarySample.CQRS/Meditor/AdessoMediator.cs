using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;

namespace MediatorLibrarySample.CQRS.Meditor
{
    internal class AdessoMediator : IAdessoMediator
    {
        private readonly IServiceProvider _serviceProvider;
        private static readonly ConcurrentDictionary<Type, dynamic> _requestHandlers = new();

        public AdessoMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TResponse> Send<TResponse>(IAdessoRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var requestType = request.GetType();

            var handler = _requestHandlers.GetOrAdd(requestType, (Activator.CreateInstance(typeof(AdessoRequestHandlerWrapper<,>).MakeGenericType(requestType, typeof(TResponse)))
                                                 ?? throw new InvalidOperationException($"Could not create wrapper type for {requestType}")));

            
            return handler.Handle(request, _serviceProvider, cancellationToken);
        }
    }
}
