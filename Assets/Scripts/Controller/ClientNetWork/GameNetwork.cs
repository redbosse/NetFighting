using Controller.Server;
using Model;
using UnityEngine;
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

        public void InvokeRPC(string methodName, IClient client, RpcType type)
        {
           
            switch (type)
            {
                case RpcType.ClientToServer:
                    
                    _server.OnRPCCommandToServer(methodName, client.GetToken());
                    
                    break;
                
                case RpcType.ServerToClient:
                    
                    _server.OnRPCCommandServerToClient(methodName);
                    
                    break;
                
                case RpcType.myself:
                    
                    _server.OnRPCCommand(methodName, client.GetToken());
                    
                    break;
                
                case RpcType.ClientToClient:
                    
                    _server.OnRPCCommandClientToClient(methodName, client.GetToken());
                    
                    break;
                
            }
            
        }

        public void InvokeRPC(string methodName, RpcType type)
        {
            
            
            switch (type)
            {
                case RpcType.ServerToClient:
                    
                    _server.OnRPCCommandServerToClient(methodName);
                    
                    break; 
                case RpcType.AnonimysToServer:
                    
                    _server.OnRPCCommandAnonymus(methodName);
                    
                    break;
            }
            
            
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