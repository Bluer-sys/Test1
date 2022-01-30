using Services.SaveLoad;
using Zenject;

namespace Installers
{
    public class SaveLoadServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ISaveLoadService>()
                .To<SaveLoadService>()
                .AsSingle()
                .NonLazy();
        }
    }
}