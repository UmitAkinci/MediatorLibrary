using MediatorLibrarySample.CQRS.Commands;

namespace MediatorLibrarySample.Application.MoneyTransfer.Command.CreateMoneyTransfer
{
    public class CreateMoneyTransferCommand:IAdessoCommand<bool>
    {
        public string SenderFullName { get; set; }
        public string ReceiverFullName { get; set; }
        public decimal Amount { get; set; }
        public long ReferenceNumber { get; set; }
    }
}
