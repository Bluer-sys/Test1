using Services.Random;
using Zenject;

namespace Installers
{
    public class RandomServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IRandomService>()
                .To<RandomService>()
                .AsSingle()
                .NonLazy();
        }
    }
}