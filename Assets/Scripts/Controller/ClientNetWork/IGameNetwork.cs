using Model;

namespace Controller.ClientNetWork
{
    public interface IGameNetwork
    {
        public string Connect(string adress, string name, Client client);
        public bool IsConnected(string token);
        public void InvokeRPC(string methodName, IClient client ,RpcType type);
        public void InvokeRPC(string methodName, RpcType type);
       
    }
}