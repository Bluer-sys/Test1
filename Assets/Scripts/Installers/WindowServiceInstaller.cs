using UI.Services;
using Zenject;

namespace Installers
{
    public class WindowServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IWindowService>()
                .To<WindowService>()
                .AsSingle()
                .NonLazy();
        }
    }
}