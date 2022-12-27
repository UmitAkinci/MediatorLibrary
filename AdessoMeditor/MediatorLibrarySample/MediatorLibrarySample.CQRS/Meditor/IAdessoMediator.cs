using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatorLibrarySample.CQRS.Commands;

namespace MediatorLibrarySample.CQRS.Meditor
{
    public interface IAdessoMediator
    {
        Task<TResponse> Send<TResponse>(IAdessoRequest<TResponse> request, CancellationToken cancellationToken = default);
    }
}
