using System.Collections.Generic;
using System.Linq;
using Model;

namespace Controller.Server
{
    public class Server : IServer
    {
        private List<Client> _clients = new List<Client>();
        
        
        public string Connected(Client client)
        {
            bool isContains = _clients.Contains(client);

            if (isContains)
            {
                return string.Empty;
            }

            _clients.Add(client);
            
            client.OnConnect();
            client.OnDisconnectEventHandler += Disconnect;
            
            return $"23asdpiuyansda; + {client.Name}";
        }

        
        public void OnRPCCommand(string cmd, string _token)
        {
            foreach (var client in _clients)
            {
                if (client.CheckToken(_token))
                {
                   client.InvokeRpcFromServer(cmd);
                }
            }
        }

        public void StartServer()
        {
            if (_clients == null)
            {
                _clients = new List<Client>();
            }
        }

        public void StopServer()
        {
            foreach (var client in _clients.ToList())
            {
                _clients.Remove(client);
                
                client.OnDisconnect();
            }
        }

        void Disconnect(Client client)
        {
            client.OnDisconnectEventHandler -= Disconnect;
            
            client.Dispose();
        }

        public void Dispose()
        {
            StopServer();
        }
    }
}