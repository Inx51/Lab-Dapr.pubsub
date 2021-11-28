# Lab - Pubsub using Dapr

## Introduction
A super simple test of pubsub using Dapr.

## Prerequisite
* [Dapr](https://dapr.io/)
* [Docker (Desktop)](https://www.docker.com/products/docker-desktop)

## Tech used
* [Dapr](https://dapr.io/)
* [Docker (Docker-compose)](https://docs.docker.com/compose/)
* [RabbitMQ](https://www.rabbitmq.com/)
* [.Net 6 (Console and WebApi/AspNetCore)](https://dotnet.microsoft.com/download/dotnet/6.0)

## Abstract

### Question to be answered
How could we use Dapr to create a simple pub-sub system?

### Why?
Using Dapr for pub-sub makes it easy to switch the underlying broker, whithout having to rewrite the "core applications/system",
This also means that the developer doesn't have to know anything about the broker specifik API.
Dapr has several other benefits as well, but they are beyond the scope of this laboration.

### When?
Could be used when writing distributed systems (such as systems built on the principles of a Microservices architecture)

## Instructions
1. Open a terminal
2. navigate to the repo

```ps
#will setup a rabbitmq container
docker-compose up
```

4. run (in a new terminal)

```ps
cd Sub
dapr run -a sub -p 5000 -d ..\components -- dotnet run --urls http://*:5000
```

5. run (in a new terminal)

```ps
cd Pub
dapr run -a pub --dapr-http-port 3500 -d ../components -- dotnet run
```

## Result
Messages are published from the .Net Pub application, to the Dapr publish sidecar, and received/subscribed to by the Dapr subscribe sidecar which then forwards the messages to the .Net Sub application.

## Discussion
Pubsub using Dapr allows us to focus more on the main concernes of the bussiness logic and less on the technicalities regarding the infrastructure of our application when runnings a distrubuted system. This benefits the developers greatly. The way Dapr de-couples the broker from our application also makes it very felxible for us to replace the broker if needed (for instance if the domain we are running our distrubuted system prefers to use a different broker then RabbitMQ, we can very easily adapt to that without having to rewrite any code of our "core system")

## References
* [Dapr pubsub docs - https://docs.dapr.io/developing-applications/building-blocks/pubsub/pubsub-overview/](https://docs.dapr.io/developing-applications/building-blocks/pubsub/pubsub-overview/)
* [Dapr pubsub RabbitMQ component - https://docs.dapr.io/reference/components-reference/supported-pubsub/setup-rabbitmq/](https://docs.dapr.io/reference/components-reference/supported-pubsub/setup-rabbitmq/)
* [Publish–subscribe pattern (pubsub) - https://en.wikipedia.org/wiki/Publish%E2%80%93subscribe_pattern](https://en.wikipedia.org/wiki/Publish%E2%80%93subscribe_pattern)