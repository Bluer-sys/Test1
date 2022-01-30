using States;
using UI.Elements;
using UI.UIFactory;
using Zenject;

namespace UI.Services
{
    public class WindowService : IWindowService
    {
        private IUIGameFactory _uiGameFactory;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IUIGameFactory uiGameFactory, IGameStateMachine gameStateMachine)
        {
            _uiGameFactory = uiGameFactory;
            _gameStateMachine = gameStateMachine;
        }

        public async void Open(WindowId windowId)
        {
            switch (windowId)
            {
                case WindowId.Unknown:
                    break;
                case WindowId.MainMenu:
                    await _uiGameFactory.CreateMainMenu();
                    break;
                case WindowId.ScoreBoard:
                    ScoreBoard scoreBoard = await _uiGameFactory.CreateScoreBoard();
                    _gameStateMachine.Enter<ScoreBoardState, ScoreBoard>(scoreBoard);
                    break;
            }
        }
    }
}