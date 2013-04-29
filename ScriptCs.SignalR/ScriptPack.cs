using System.Collections.Generic;

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
}