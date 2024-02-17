using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo.API.Hubs
{
    public class MyHub : Hub
    {
        public static List<string> names {  get; set; } = new List<string>();

        public async Task SendName(string name)
        {
            await Clients.All.SendAsync("ReceiveName", name);

        }

        public async Task GetAll()
        {
            await Clients.All.SendAsync("ReceiveNames", names);
        }
    }
}
