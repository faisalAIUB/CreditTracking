using CreditTracker.Domain.Abstractions;
using CreditTracker.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Domain.Models
{
    public class CreditEntry : Aggregate<string>
    {
        public string ShopId { get; private set; }
        public string CustomerId { get; private set; }
        public string Item { get; private set; } = default!;
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public bool IsPaid { get; private set; }
        public DateTime? PaymentDate { get; private set; }

        public static CreditEntry Create(string shopId, string customerId, string item, decimal amount, DateTime date, bool isPaid, DateTime? paymentDate)
        {
            var entry = new CreditEntry
            {
                ShopId = shopId,
                CustomerId = customerId,
                Item = item,
                Amount = amount,
                Date = date,
                IsPaid = isPaid,
                PaymentDate = paymentDate
            };
            entry.AddDomainEvent(new CreditEntryCreatedEvent(entry));
            return entry;
        }
        public void Update(bool ispaid, DateTime paymentDate)
        {
            IsPaid = ispaid;
            PaymentDate = paymentDate;
            AddDomainEvent(new CreditEntryUpdatedEvent(this));
        }
    }
}
