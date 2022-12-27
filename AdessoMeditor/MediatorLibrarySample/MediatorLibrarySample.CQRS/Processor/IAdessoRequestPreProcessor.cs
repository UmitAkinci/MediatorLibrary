using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrarySample.CQRS.Processor
{
    public interface IAdessoRequestPreProcessor<in TRequest>
        where TRequest : notnull
    {
        Task Process(TRequest request, CancellationToken cancellationToken);
    }
}
