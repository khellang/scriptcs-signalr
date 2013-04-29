public class ChatHub : Hub
{
	public void Send(string message) { }
}

var signalr = Require<SignalR>();

signalr.StartServer("http://localhost:8080");