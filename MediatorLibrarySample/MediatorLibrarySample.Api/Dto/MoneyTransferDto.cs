namespace MediatorLibrarySample.Api.Dto
{
    public class MoneyTransferDto
    {
        public string SenderFullName { get; set; }
        public string ReceiverFullName { get; set; }
        public decimal Amount { get; set; }
        public long ReferenceNumber { get; set; }
    }
}
