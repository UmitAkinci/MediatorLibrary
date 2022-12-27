using MediatorLibrarySample.Application.MoneyTransfer.Command.CreateMoneyTransfer;
using MediatorLibrarySample.CQRS.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrarySample.Application.MoneyTransfer
{
    public class CreateMoneyTransferCommandPreProcessor<TRequest> : IAdessoRequestPreProcessor<TRequest> where TRequest : notnull
    {
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
