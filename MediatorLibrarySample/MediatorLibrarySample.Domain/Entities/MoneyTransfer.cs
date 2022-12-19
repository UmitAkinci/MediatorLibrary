using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrarySample.Domain.Entities
{
    public class MoneyTransfer : BaseEntity
    {
        public MoneyTransfer(string senderFullName, string receiverFullName, decimal amount, long referenceNumber)
        {
            SenderFullName = senderFullName;
            ReceiverFullName = receiverFullName;
            Amount = amount;
            ReferenceNumber = referenceNumber;
        }

        public string SenderFullName { get; set; }
        public string ReceiverFullName { get; set; }
        public decimal Amount { get; set; }
        public long ReferenceNumber { get; set; }

    }
}
