using UI.UIFactory;
using Zenject;

namespace Installers
{
    public class UIFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IUIGameFactory>()
                .To<UIGameFactory>()
                .AsSingle()
                .NonLazy();
        }
    }
}