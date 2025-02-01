using System;
using Model;

namespace Controller.Server
{
    public interface IServer : IDisposable
    {
        public string Connected(Model.Client client);

        public void OnRPCCommand(string cmd, string _token);
        public void StartServer();
        public void StopServer();
    }
}