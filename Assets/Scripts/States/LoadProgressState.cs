using Data;
using Services.Progress;
using Services.SaveLoad;

namespace States
{
    public class LoadProgressState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IPersistentProgress _persistentProgress;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(IGameStateMachine gameStateMachine, IPersistentProgress persistentProgress, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _persistentProgress = persistentProgress;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrCreateNew();
            
            _gameStateMachine.Enter<MainMenuState>();
        }

        public void Exit()
        {
        }

        private void LoadProgressOrCreateNew()
        {
            _persistentProgress.Progress = _saveLoadService.LoadProgress() ?? new PlayerProgress();
        }
    }
}