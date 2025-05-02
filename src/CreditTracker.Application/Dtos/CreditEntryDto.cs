using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Application.Dtos
{
    public class CreditEntryDto
    {
        public string Id { get; set; } = default!;
        public string ShopId { get; set; } = default!;
        public string ShopName {  get; set; } = default!;
        public string CustomerId { get; set; } = default!;
        public string CustomerName { get; set; } = default!;
        public string Item { get; set; } = default!;
        public decimal Amount { get; set; } = default!;
        public DateTime Date { get; set; } = default!;
        public bool IsPaid { get; set; } = default!;
        public DateTime? PaymentDate { get; set; } = default!;
    }
}
