using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;

namespace WebAppRazorPages.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            HttpContext httpContext = Context.GetHttpContext();

            string receiver = httpContext.Request.Query["userid"];
            string sender = Context.User.Claims.FirstOrDefault().Value;

            Groups.AddToGroupAsync(Context.ConnectionId, sender);
            if (!string.IsNullOrEmpty(receiver))
            {
                Groups.AddToGroupAsync(Context.ConnectionId, receiver);
            }

            return base.OnConnectedAsync();
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public Task SendMessageToGroup(string receiver, string message)
        {
            return Clients.Group(receiver).SendAsync("ReceiveMessage"
                , Context.User.Identity.Name, message);
        }
    }
}
