using System;

using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;

using Owin;

using ScriptCs.Contracts;

namespace ScriptCs.SignalR
{
    public class SignalR : IScriptPackContext
    {
        public void StartServer(string url)
        {
            using (WebApplication.Start<Server>(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }

        private class Server
        {
            private readonly string _path;

            private readonly HubConfiguration _config;

            public Server(string path = null, HubConfiguration config = null)
            {
                _path = path ?? "/signalr";
                _config = config ?? new HubConfiguration()
                {
                    EnableCrossDomain = true,
                    EnableDetailedErrors = true
                };
            }

            public void Configuration(IAppBuilder app)
            {
                app.MapHubs(_path, _config);
            }
        }
    }
}