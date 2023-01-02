using MediatorLibrarySample.Application.MoneyTransfer.Command.CreateMoneyTransfer;
using MediatorLibrarySample.CQRS;
using MediatorLibrarySample.CQRS.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrarySample.Application.MoneyTransfer
{
    public class MyTestPostProcessor<TRequest, TResponse> : IAdessoRequestPostProcessor<TRequest, TResponse> where TRequest : IAdessoRequest<TResponse>
    {
        public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            //Somethings to do...
            return Task.CompletedTask;
        }
    }
}
