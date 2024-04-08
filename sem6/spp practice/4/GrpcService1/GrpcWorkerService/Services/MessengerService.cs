using Grpc.Core;
using GrpcWorkerService;
using System.Text.Json;

namespace GrpcWorkerService.Services
{
    public class MessengerService : Messenger.MessengerBase
    {
        private readonly ILogger<MessengerService> _logger;
        public MessengerService(ILogger<MessengerService> logger)
        {
            _logger = logger;
        }

        string[] messages = { "Привет", "Как дела?", "Че молчишь?", "Ты че, спишь?", "Ну пока" };
        List<Worker> workers = new List<Worker>()
        {
            new Worker("Alex", 21, "an engineer"),
            new Worker("Semen", 23, "a waiter"),
            new Worker("Sam", 21, "a lawyer"),
            new Worker("Mike", 27, "a doctor")
        };

        public Worker GetWorker()
        {
            return workers[new Random().Next(workers.Count)];
        }

        public override async Task ServerDataStream(Request request,
            IServerStreamWriter<Response> responseStream,
            ServerCallContext context)
        {
            while(true)
            { 
                var workerJson = JsonSerializer.Serialize(GetWorker());
                await responseStream.WriteAsync(new Response { Content = workerJson });
                await Task.Delay(TimeSpan.FromSeconds(4));
            }
        }
    }
}