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
            Task<TResponse> Handler() => serviceProvider.GetRequiredService<IAdessoRequestHandler<TRequest, TResponse>>().Handle((TRequest)request, cancellationToken);
            var a = serviceProvider
                .GetServices<IAdessoPipelineBehavior<TRequest, TResponse>>();
            return serviceProvider
                .GetServices<IAdessoPipelineBehavior<TRequest, TResponse>>()
                .Reverse()
                .Aggregate((RequestHandlerDelegate<TResponse>)Handler, (next, pipeline) => () => pipeline.Handle((TRequest)request, next, cancellationToken))();
        }
    }

}
