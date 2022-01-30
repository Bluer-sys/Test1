using Services;
using Zenject;

namespace Installers
{
    public class AssetProviderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IAssetProvider>()
                .To<AssetProvider>()
                .AsSingle()
                .NonLazy();
        }
    }
}