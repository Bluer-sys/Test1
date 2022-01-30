using Services.Progress;
using Zenject;

namespace Installers
{
    public class PersistentProgressInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IPersistentProgress>()
                .To<PersistentProgress>()
                .AsSingle()
                .NonLazy();
        }
    }
}
