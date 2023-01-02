using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrarySample.CQRS.Processor
{
    public interface IAdessoRequestPostProcessor<in TRequest, in TResponse> where TRequest : IAdessoRequest<TResponse>
    {
        /// <summary>
        /// Process method executes after the Handle method on your handler
        /// </summary>
        /// <param name="request">Request instance</param>
        /// <param name="response">Response instance</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>An awaitable task</returns>
        Task Process(TRequest request, TResponse response, CancellationToken cancellationToken);
    }
}
