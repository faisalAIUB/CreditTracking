using BuildingBlocks.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Application.Exception
{
    public class CreditEntryNotFoundException : NotFoundException
    {
        public CreditEntryNotFoundException(string Id) : base("CreditEntry", Id)
        {
        }
    }
}
