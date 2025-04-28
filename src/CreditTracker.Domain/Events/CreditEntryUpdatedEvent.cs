using CreditTracker.Domain.Abstractions;
using CreditTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Domain.Events
{
    public record CreditEntryUpdatedEvent(CreditEntry CreditEntry):IDomainEvent;
    
}
