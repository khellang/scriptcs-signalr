using System;
using System.Collections.Generic;

using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;

using Owin;

using ScriptCs.Contracts;

namespace ScriptCs.SignalR
{
    public class ScriptPack : IScriptPack
    {
        public void Initialize(IScriptPackSession session)
        {
            var namespaces = new List<string>
            {
                "Microsoft.AspNet.SignalR", 
                "Microsoft.AspNet.SignalR.Hubs"
            };

            namespaces.ForEach(session.ImportNamespace);
        }

        public IScriptPackContext GetContext()
        {
            return new SignalR();
        }

        public void Terminate() { }
    }

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
    }

    public class Server
    {
        private readonly string _path;

        private readonly HubConfiguration _config;

        public Server(string path = null, HubConfiguration config = null)
        {
            _path = path ?? "/signalr";
            _config = config ?? new HubConfiguration();
        }

        public void Configuration(IAppBuilder app)
        {
            app.MapHubs(_path, _config);
        }
    }
}