using Services.Ads;
using Zenject;

namespace Installers
{
    public class AdsServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IAdsService>()
                .To<AdsService>()
                .AsSingle()
                .NonLazy();
        }
    }
}