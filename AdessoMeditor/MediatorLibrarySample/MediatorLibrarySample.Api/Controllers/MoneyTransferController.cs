using MediatorLibrarySample.Api.Dto;
using MediatorLibrarySample.Application.MoneyTransfer.Command.CreateMoneyTransfer;
using MediatorLibrarySample.Application.MoneyTransfer.Query;
using MediatorLibrarySample.CQRS.Meditor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediatorLibrarySample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoneyTransferController : Controller
    {
        private readonly IAdessoMediator _mediator;

        public MoneyTransferController(IAdessoMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<object?> Create([FromBody] MoneyTransferDto moneyTransferDto)
        {
            var request = new CreateMoneyTransferCommand
            {
                Amount = moneyTransferDto.Amount,
                ReceiverFullName = moneyTransferDto.ReceiverFullName,
                ReferenceNumber = moneyTransferDto.ReferenceNumber,
                SenderFullName = moneyTransferDto.SenderFullName
            };
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<bool> GetListAsync(string param)
        {
            var request = new CreateMoneyTransferQuery
            {
                SenderFullName = param
            };
            var result = await _mediator.Send(request);
            return true;
        }
    }
}
