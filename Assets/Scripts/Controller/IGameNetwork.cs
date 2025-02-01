using Model;

namespace Controller
{
    public interface IGameNetwork
    {
        public string Connect(string adress, string name, Client client);
        public bool IsConnected(string token);
    }
}