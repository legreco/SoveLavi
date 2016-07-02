using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SoveLaviUI
{
    public class MapEventHub : Hub
    {

        IHubContext hubContext;
        public MapEventHub()
        {
            hubContext = GlobalHost.ConnectionManager.GetHubContext<MapEventHub>();
        }
      
        public void Send(string eventName, float lattitude, float longittude)
        {
            // Call the broadcastMessage method to update clients.
            hubContext.Clients.All.broadcastMessage(eventName, lattitude, longittude);
        }
    }
}