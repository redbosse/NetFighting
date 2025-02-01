using System;
using Model;

namespace Controller
{
    public interface IServer : IDisposable
    {
        public string Connected(Client client);

        public void StartServer();
        public void StopServer();
    }
}