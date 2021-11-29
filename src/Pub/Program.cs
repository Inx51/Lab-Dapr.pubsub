using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Bogus;
using Dapr.Client;
using Pub;

//Publish event in two different ways.
await PublishUsingHttpApiAsync();
await PublishUsingDaprClientAsync();

async Task PublishUsingHttpApiAsync()
{
    var httpClient = new HttpClient();
    var daprPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT");

    for(var i = 0; i < 10; i++)
    {
        var data = $"{{\"key:\":{i}}}";
        Console.WriteLine($"Sending {data}");

        var stringContent = new StringContent(data, Encoding.UTF8);
        var resposne = await httpClient.PostAsync($"http://localhost:{daprPort}/v1.0/publish/rabbitmq.pubsub/someevent", stringContent);
    }   
}

async Task PublishUsingDaprClientAsync()
{
    var faker = new Faker<User>();
    faker.RuleFor(p => p.Age, f => f.Random.Number(1,100));
    faker.RuleFor(p => p.FirstName, f => f.Person.FirstName);
    faker.RuleFor(p => p.LastName, f => f.Person.LastName);

    var daprClient = new DaprClientBuilder().Build();
    for(var i = 0; i < 10; i++)
    {
        var data = faker.Generate(1).First();
        var json = JsonSerializer.Serialize(data);
        Console.WriteLine($"Sending {json}");
        await daprClient.PublishEventAsync("rabbitmq.pubsub", "someevent", json);
    }   
}