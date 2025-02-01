namespace Controller.Server
{
    interface IServerRPC
    {
        public void InvokeRpcFromServer(string cmd);
    }
}