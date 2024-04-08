using Grpc.Net.Client;
using GrpcMessageClient;
using GrpcWorkerService;
using System.Text.Json;
class Program
{
    public static async Task Main()
    {
        using var channel = GrpcChannel.ForAddress("https://localhost:6969");
        var client = new GrpcMessageClient.Messenger.MessengerClient(channel);

        var serverData = client.ServerDataStream(new Request());

        var responseStream = serverData.ResponseStream;
        while (await responseStream.MoveNext(new CancellationToken()))
        {
            Response response = responseStream.Current;
            var worker = JsonSerializer.Deserialize<Worker>(response.Content);
            worker.Introduce();
            //Console.WriteLine(response.Content);
        }
        Console.ReadKey();

    }
}