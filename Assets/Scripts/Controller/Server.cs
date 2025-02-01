using System.Collections.Generic;
using System.Linq;
using Model;
using UnityEngine;

namespace Controller
{
    public class Server : IServer
    {
        private List<Client> _clients = new List<Client>();
        
        public string Connected(Client client)
        {
            bool isContains = _clients.Contains(client);

            if (isContains)
            {
                return "";
            }

            _clients.Add(client);
            
            client.OnConnect();
            client.OnDisconnectEventHandler += Disconnect;
            
            return $"23asdpiuyansda; + {client.Name}";
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