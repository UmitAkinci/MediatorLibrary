using MediatorLibrarySample.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrarySample.CQRS.Processor
{

    internal class AdessoRequestPreProcessorBehavior<TRequest, TResponse> : IAdessoPipelineBehavior<TRequest, TResponse>
    where TRequest : IAdessoRequest<TResponse>
    {
        private readonly IEnumerable<IAdessoRequestPreProcessor<TRequest>> _preProcessors;

        public AdessoRequestPreProcessorBehavior(IEnumerable<IAdessoRequestPreProcessor<TRequest>> preProcessors)
            => _preProcessors = preProcessors;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            foreach (var processor in _preProcessors)
            {
                await processor.Process(request, cancellationToken).ConfigureAwait(false);
            }

            return await next().ConfigureAwait(false);
        }
    }
}
