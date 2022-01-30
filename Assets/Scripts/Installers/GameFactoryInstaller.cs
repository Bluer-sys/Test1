using Services.Factory;
using Zenject;

namespace Installers
{
    public class GameFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IGameFactory>()
                .To<GameFactory>()
                .AsSingle()
                .NonLazy();
        }
    }
}