using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Messages.Commands;
using Domain.Messages.Events;
using MassTransit;

namespace CustomerCreationService
{
    class Program
    {
        static void Main(string[] args)
        {
            Bus.Initialize(sbc =>
            {
                sbc.UseRabbitMq();
                sbc.ReceiveFrom("rabbitmq://guest:guest@dev_rabbitmq/sample.customercreationservice");
            });
            Bus.Instance.SubscribeHandler<CreateCustomer>(msg => CreateCustomer(msg));

            Console.WriteLine("Customer Creation Service started");
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        public static void CreateCustomer(CreateCustomer command)
        {
            Console.WriteLine("Creating Customer: {0} {1} with Id: {2}", command.FirstName, command.LastName, command.Id);
            // simulating we do stuff
            Thread.Sleep(1000);

            // worked or failed?
            var resultOk = new Random().Next(1000) < 800;
            if (resultOk)
                Bus.Instance.Publish<CustomerCreated>(
                    new CustomerCreated
                    {
                        Id = command.Id
                    });
            else
                Bus.Instance.Publish<CustomerCreationFailed>(
                    new CustomerCreationFailed
                    {
                        Id = command.Id,
                        Reason = "Bad Luck!"
                    });
        }
    }
}
