
using Controller;
using Model;

using Zenject;

namespace ZenjectInstallers
{
    public class ClientInstaller : MonoInstaller<ServerInstaller>
    {
      
        public override void InstallBindings()
        {
            Container.Bind<IServer>().To<Server>().AsSingle();
            
            Container.Bind<IGameNetwork>().To<GameNetwork>().AsSingle();
            
            Container.Bind<IClient>().To<Client>().AsTransient();



        }
    }
}