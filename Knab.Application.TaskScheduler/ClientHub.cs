using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Knab.Application.TaskScheduler
{
    public class ClientHub : Hub
    {
        public async Task Send(string name, string message)
        {
            await Clients.All.SendAsync(name, message);
        }
    }
}