using System;
using Model;
using Zenject;

namespace Controller.Server
{
    public interface IServer : IDisposable, IInitializable
    {
        public string Connected(Model.Client client);

        public void OnRPCCommand(string cmd, string _token);
        public void OnRPCCommandToServer(string cmd, string _token);
        public void OnRPCCommandClientToClient(string cmd, string _token);
        public void OnRPCCommandServerToClient(string cmd);
        public void StartServer();
        public void StopServer();
    }
}