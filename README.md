MassTransitSample
=================

This sample provides an example of a system using MassTransit over RabbitMQ for messaging.  
To use it, you have to:  
1. Install RabbitMQ. Have a look at http://www.rabbitmq.com/install-windows.html
2. Change in the source code the Rabbit URL "rabbitmq://guest:guest@dev_rabbitmq" for whatever your configuration is (typically "rabbitmq://localhost"). The path of the URL MUST NOT BE CHANGED! (e.g. rabbitmq://guest:guest@dev_rabbitmq/sample.whatever -> rabbitmq://localhost/sample.whatever)
  
There are three messages defined: One command and two events.  
The difference between a comamnd and an event is:
* A command is processed by one service but can be sent by many. It is defined by the consumer/processor service
* An event is processed my many services but can be sent only by one. It is defined by the service triggering it.

![System schema](/schema.png "System schema")
