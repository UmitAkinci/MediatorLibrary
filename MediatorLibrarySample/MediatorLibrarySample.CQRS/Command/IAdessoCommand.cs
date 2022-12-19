using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrarySample.CQRS.Commands
{
    public interface IAdessoCommand<out TResponse> : IAdessoRequest<TResponse>
    {
    }
}
