using System.Threading.Tasks;

using Microsoft.AspNet.SignalR.Hubs;

namespace ScriptCs.SignalR
{
    public static class ClientProxyExtensions
    {
        public static Task Invoke(this object obj, string method, params object[] args)
        {
            var clientProxy = obj as IClientProxy;
            if (clientProxy != null)
            {
                return clientProxy.Invoke(method, args);
            }

            return null;
        }
    }
}