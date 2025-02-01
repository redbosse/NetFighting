
using Controller;
using Controller.Server;
using Controller.ClientNetWork;
using Controller.Hp;
using Model;

using Zenject;

namespace ZenjectInstallers
{
    public class ClientInstaller : MonoInstaller<ServerInstaller>
    {
      
        public override void InstallBindings()
        {
            
            Container.Bind<IGameNetwork>().To<GameNetwork>().AsSingle();
            
            Container.Bind<HpController>().AsTransient();
            
            Container.Bind<IClient>().To<Client>().AsTransient();
            
        }
    }
}