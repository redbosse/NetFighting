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
            Container.Bind<IServer>().To<Server>().AsSingle();
            
        }
    }
}