using Model;
using Zenject;

namespace Controller
{
    public class GameNetwork : IGameNetwork
    {
        [Inject] 
        private IServer _server;
        
        public string Connect(string adress, string name, Client client)
        {
           
            return _server.Connected(client);
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