## Intro
This is just a super simple sample of using rabbitmq and .Net 6 with Dapr to handle a simple pubsub. Which can be used in distrubuted systems such as in a Microservies Architecture

## Requirmenets
* [Dapr](https://dapr.io/)
* [Docker (Desktop)](https://www.docker.com/products/docker-desktop)

## Tech used
* [Dapr](https://dapr.io/)
* [Docker (Docker-compose)](https://docs.docker.com/compose/)
* [RabbitMQ](https://www.rabbitmq.com/)
* [.Net 6 (Console and WebApi/AspNetCore)](https://dotnet.microsoft.com/download/dotnet/6.0)

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

6. watch the messages getting published from pub app and subscribed by the sub app.