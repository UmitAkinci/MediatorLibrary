using MediatorLibrarySample.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrarySample.CQRS
{
    public interface IAdessoRequestHandler<in TRequest, TResponse>
        where TRequest : IAdessoRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
