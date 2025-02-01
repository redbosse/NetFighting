using Controller.Server;
using Model;
using Zenject;

namespace Controller.ClientNetWork
{
    public class GameNetwork : IGameNetwork
    {
        [Inject] 
        private IServer _server;
        
        public string Connect(string adress, string name, Model.Client client)
        {
           
            return _server.Connected(client);
        }

        public void InvokeRPC(string methodName, IClient client)
        {
            _server.OnRPCCommand(methodName, client.GetToken());
        }

        public bool IsConnected(string token)
        {
            return ValidateToken(token);
        }

        private bool ValidateToken(string token)
        {
            return true;
        }
    }
}