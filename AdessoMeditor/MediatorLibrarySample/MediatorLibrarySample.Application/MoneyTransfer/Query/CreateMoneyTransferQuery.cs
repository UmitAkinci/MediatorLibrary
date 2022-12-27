using MediatorLibrarySample.CQRS.Commands;
using MediatorLibrarySample.CQRS.Queries;

namespace MediatorLibrarySample.Application.MoneyTransfer.Query
{
    public class CreateMoneyTransferQuery : IAdessoQuery<bool>
    {
        public string SenderFullName { get; set; }
    }
}
