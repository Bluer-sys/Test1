using UI.Services;

namespace States
{
    public class MainMenuState : IState
    {
        private readonly IWindowService _windowService;
        public MainMenuState(IWindowService windowService)
        {
            _windowService = windowService;
        }

        public void Enter()
        {
            _windowService.Open(WindowId.MainMenu);
        }

        public void Exit()
        {
        }
    }
}