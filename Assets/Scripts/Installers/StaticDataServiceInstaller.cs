using Services.StaticData;
using Zenject;

namespace Installers
{
    public class StaticDataServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IStaticDataService>()
                .To<StaticDataService>()
                .AsSingle()
                .NonLazy();
        }
    }
}