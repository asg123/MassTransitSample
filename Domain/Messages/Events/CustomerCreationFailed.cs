using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Messages.Events
{
    public class CustomerCreationFailed
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
    }
}
