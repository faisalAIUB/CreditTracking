using CreditTracker.Domain.Abstractions;
using CreditTracker.Domain.Events;


namespace CreditTracker.Domain.Models
{
    public class CreditEntry : Aggregate<string>
    {
        public string ShopId { get; private set; } = default!;
        public string ShopName { get; private set; } = default!;
        public string CustomerId { get; private set; } = default!;
        public string CustomerName {  get; private set; } = default!;
        public string Item { get; private set; } = default!;
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public bool IsPaid { get; private set; }
        public DateTime? PaymentDate { get; private set; }

        public static CreditEntry Create(string shopId, string shopName, string customerId, string customerName, string item, decimal amount, DateTime date, bool isPaid, DateTime? paymentDate)
        {
            var entry = new CreditEntry
            {
                ShopId = shopId,
                ShopName = shopName,
                CustomerId = customerId,
                CustomerName = customerName,
                Item = item,
                Amount = amount,
                Date = date,
                IsPaid = isPaid,
                PaymentDate = paymentDate,
                IsActive = true
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
