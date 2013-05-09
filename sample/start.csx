public class ChatHub : Hub
{
	public void Send(string message) 
	{ 
		Clients.All.Invoke("addMessage", message);
	}
}

var signalr = Require<SignalR>();

signalr.StartServer("http://localhost:8080");