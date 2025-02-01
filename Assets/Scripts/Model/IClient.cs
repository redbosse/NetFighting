using System;



namespace Model
{
    public interface IClient: IDisposable
    { 
        public event Action<Client> OnDisconnectEventHandler;
        public void StartClient(string name);
        public void OnConnect();

        public bool CheckToken(string token);
        
        public string GetToken();
        public void SubscribeToRPC(IRpcMethod rpcMethod);
        public void UnSubscribeToRPC(IRpcMethod rpcMethod);
    
        public void OnDisconnect();
        
    }
}