using System;

namespace Domain.Messages.Commands
{
    public sealed class CreateCustomer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
