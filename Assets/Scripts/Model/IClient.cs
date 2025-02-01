using System;
using Controller;
using Zenject;


namespace Model
{
    public interface IClient: IDisposable
    { 
        public event Action<Client> OnDisconnectEventHandler;
        public void StartClient(string name);
        public void OnConnect();

        public void SetNetworkInstance(IGameNetwork networkInstance);
        public void OnDisconnect();
        
    }
}