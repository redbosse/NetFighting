using System;
using System.Collections.Generic;
using Controller.ClientNetWork;
using Controller.Server;
using NUnit.Framework;
using Unity.Collections.LowLevel.Unsafe;
using Zenject;


namespace Model
{
    public class Client : IClient, IServerRPC
    {
        private string _token;
        
        List<IRpcMethod> _rpcMethods = new List<IRpcMethod>();
        
        public string Name { get; set; }

        public event Action<Client> OnDisconnectEventHandler;

        [Inject] 
        private IGameNetwork _network;

        public void StartClient(string name)
        {
            Name = name;
            
           _token = _network.Connect("127.0.0.1",name,this);
           
           if (string.IsNullOrEmpty(_token))
           {
               throw new Exception("Failed to connect to server");
           }
           
           OnConnect();
           
        }
        
        public void OnConnect()
        {
            
        }

        public bool CheckToken(string token)
        {
           return _token == token;
        }

        public string GetToken()
        {
            return _token;
        }
        
        public void SubscribeToRPC(IRpcMethod rpcMethod)
        {
            _rpcMethods.Add(rpcMethod);
        }

        public void UnSubscribeToRPC(IRpcMethod rpcMethod)
        {
            _rpcMethods.Remove(rpcMethod);
        }

        public void InvokeRpcFromServer(string cmd)
        {
            foreach (var method in _rpcMethods)
            {
                method.RPCMethod(cmd);
            }
        }

        public void OnDisconnect()
        {
            OnDisconnectEventHandler?.Invoke(this);   
        }


        public void Dispose()
        {
            
        }
        
    }
}