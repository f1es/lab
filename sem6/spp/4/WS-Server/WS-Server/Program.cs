using System.Net;
using System.Net.WebSockets;
using System.Text;
using WS_Server;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("https://localhost:6969");
var app = builder.Build();
app.UseWebSockets();
var connections = new List<WebSocket>();

var ads = new List<string>() 
{ 
    "Ирина 100 метров от вас", 
    "Курсы Skills со скидкой 50% | Онлайн-курсы Скилс",
    "Collect over 700 Champions and take down your opponents in RAID: Shadow Legends. Explore 1+ million Champion builds in this dark fantasy Collection MMORPG!",
    "betbetbet – лучшая букмекерская контора в мире.",
    "Преодолевай границы вместе с новинкой от Святой Источник!",
    "Хочешь сладких апельсинов🍊?",
    "Энергетический напиток Имба Энерджи для повышения бодрости и концентрации внимания геймера. ⚡ Попробуй и затащи!",
    "Скидки в GeekBrains до 70%. Внутренняя рассрочка. Успейте записаться! Начните работать по профессии уже через 6 месяцев. 95% наших учеников трудоустроены!",
    "500+ Brilliant Puzzles await",
    "Aviasales.by помогает найти и купить самые дешёвые авиабилеты✈. Поиск билетов на самолёт по 728 авиакомпаниям, ведущим авиакассам и лучшие цены на ..."
};

app.Map("/ws", async context =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        using var ws = await context.WebSockets.AcceptWebSocketAsync();
        connections.Add(ws);

        while (true)
        {
            var message = ListUtility<string>.GetRandom(ads);
            if (ws.State == WebSocketState.Open)
            {
                await Broadcast(message);
            }
            else if (ws.State == WebSocketState.Closed || ws.State == WebSocketState.Aborted)
                break;
            Thread.Sleep(new Random().Next(1500, 3500));
        }
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
    }
});

async Task Broadcast(string message)
{
    var bytes = Encoding.UTF8.GetBytes(message);
    foreach (var soket in connections)
    {
        if (soket.State == WebSocketState.Open)
        {
            var arraySegment = new ArraySegment<byte>(bytes, 0, bytes.Length);
            await soket.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}

await app.RunAsync();
