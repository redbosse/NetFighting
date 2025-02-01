using System;
using Controller;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Model
{
    
    public class Client : IClient
    {
        private string _token;

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

        public void SetNetworkInstance(IGameNetwork networkInstance)
        {
            _network = networkInstance;
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