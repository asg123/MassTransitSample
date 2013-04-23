using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Messages.Events;
using MassTransit;

namespace LoggerService
{
    class Program
    {
        static void Main(string[] args)
        {
            Bus.Initialize(sbc =>
            {
                sbc.UseRabbitMq();
                sbc.UseRabbitMqRouting();
                sbc.ReceiveFrom("rabbitmq://guest:guest@dev_rabbitmq/sample.loggerservice");
            });
            Bus.Instance
                .SubscribeHandler<CustomerCreated>(
                msg =>
                    Console.WriteLine("Customer created OK: {0}", msg.Id));
            Bus.Instance
                .SubscribeHandler<CustomerCreationFailed>(
                msg =>
                    Console.WriteLine("Customer creation failed: {0} {1}", msg.Id, msg.Reason));

            Console.WriteLine("Logger Service started");
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
