using Controller;
using Controller.Server;
using Model;
using Zenject;

namespace ZenjectInstallers
{
    public class ServerInstaller : MonoInstaller<ServerInstaller>
    {
        public override void InstallBindings()
        {
           // Container.Bind<IGameNetwork>().To<GameNetwork>().AsSingle(); // - это нужно сделать ели сервер будет в отдельном проекте
            
            Container.Bind(typeof(IServer),typeof(IInitializable)).To<Server>().AsSingle();
            
        }
    }
}