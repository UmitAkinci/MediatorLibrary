using MediatorLibrarySample.Domain.Repository;
using MediatorLibrarySample.CQRS.Commands;

namespace MediatorLibrarySample.Application.MoneyTransfer.Command.CreateMoneyTransfer
{
    public class CreateMoneyTransferCommandHandler : AdessoCommandHandler<CreateMoneyTransferCommand, bool>
    {
        private readonly IMoneyTransferRepository _moneyTransferRepository;

        public CreateMoneyTransferCommandHandler(IMoneyTransferRepository moneyTransferRepository)
        {
            _moneyTransferRepository = moneyTransferRepository;
        }
        public override async Task<bool> Handle(CreateMoneyTransferCommand request, CancellationToken cancellationToken)
        {
            var moneyTransfer = new Domain.Entities.
                MoneyTransfer(request.SenderFullName, request.ReceiverFullName, request.Amount, request.ReferenceNumber);
            await _moneyTransferRepository.AddAsync(moneyTransfer);
            return true;
        }
    }
}
