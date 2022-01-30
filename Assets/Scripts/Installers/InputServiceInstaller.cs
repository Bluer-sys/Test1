using Services.Input;
using Zenject;

namespace Installers
{
    public class InputServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IInputService>()
                .To<StandaloneInputService>()
                .AsSingle()
                .NonLazy();
        }
    }
}
