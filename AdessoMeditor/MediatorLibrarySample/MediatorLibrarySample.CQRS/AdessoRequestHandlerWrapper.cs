using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrarySample.CQRS
{
    public delegate Task<TResponse> RequestHandlerDelegate<TResponse>();

    internal class AdessoRequestHandlerWrapper<TRequest, TResponse>
        where TRequest : IAdessoRequest<TResponse>
    {

        public AdessoRequestHandlerWrapper()
        {
        }

        public Task<TResponse> Handle(IAdessoRequest<TResponse> request, IServiceProvider serviceProvider,
    CancellationToken cancellationToken)
        {
            dynamic handler = serviceProvider.GetRequiredService(typeof(IAdessoRequestHandler<TRequest, TResponse>));

            Task<TResponse> Handler() => handler.Handle((TRequest)request, cancellationToken);

            return ((IEnumerable<dynamic>)serviceProvider.GetServices(typeof(IAdessoPipelineBehavior<TRequest, TResponse>))).Aggregate((RequestHandlerDelegate<TResponse>)Handler, (next, pipeline) => () => pipeline.Handle((TRequest)request, next, cancellationToken))();
        }
    }
}
