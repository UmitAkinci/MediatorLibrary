using MediatorLibrarySample.CQRS.Commands;
using MediatorLibrarySample.CQRS.Queries;

namespace MediatorLibrarySample.Application.MoneyTransfer.Query
{
    public class CreateMoneyTransferQueryHandler : AdessoQueryHandler<CreateMoneyTransferQuery, bool>
    {
        public override async Task<bool> Handle(CreateMoneyTransferQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return true;
        }
    }
}
