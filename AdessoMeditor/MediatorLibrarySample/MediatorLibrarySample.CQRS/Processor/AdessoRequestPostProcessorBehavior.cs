using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrarySample.CQRS.Processor
{
    internal class AdessoRequestPostProcessorBehavior<TRequest, TResponse> : IAdessoPipelineBehavior<TRequest, TResponse>
    where TRequest : IAdessoRequest<TResponse>
    {
        private readonly IEnumerable<IAdessoRequestPostProcessor<TRequest, TResponse>> _postProcessors;

        public AdessoRequestPostProcessorBehavior(IEnumerable<IAdessoRequestPostProcessor<TRequest, TResponse>> postProcessors)
            => _postProcessors = postProcessors;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next().ConfigureAwait(false);

            foreach (var processor in _postProcessors)
            {
                await processor.Process(request, response, cancellationToken).ConfigureAwait(false);
            }

            return response;
        }
    }
}
