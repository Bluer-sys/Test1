using Services.Ads;
using Services.SaveLoad;

namespace States
{
    public class GameLoopState : IState
    {
        private readonly IAdsService _adsService;
        private readonly ISaveLoadService _saveLoadService;

        public GameLoopState(IAdsService adsService, ISaveLoadService saveLoadService)
        {
            _adsService = adsService;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            _adsService.ShowBanner();
        }

        public void Exit()
        {
            _adsService.HideBanner();

            _saveLoadService.SaveProgress();
        }
    }
}