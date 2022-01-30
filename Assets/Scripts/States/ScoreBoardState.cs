using Services.Factory;
using Services.SaveLoad;
using UI.Elements;
using UI.UIFactory;

namespace States
{
    public class ScoreBoardState : IPayloadedState<ScoreBoard>
    {
        private readonly IUIGameFactory _uiGameFactory;
        private readonly IGameFactory _gameFactory;
        private readonly ISaveLoadService _saveLoadService;

        private ScoreBoard _scoreBoard;
        
        public ScoreBoardState(IUIGameFactory uiGameFactory, IGameFactory gameFactory, ISaveLoadService saveLoadService)
        {
            _uiGameFactory = uiGameFactory;
            _gameFactory = gameFactory;
            _saveLoadService = saveLoadService;
        }

        public void Enter(ScoreBoard scoreBoard)
        {
            _scoreBoard = scoreBoard;
            
            _saveLoadService.InformProgressWatchers();
            _scoreBoard.SetRecords();
        }

        public void Exit()
        {
            _uiGameFactory.Reset();
            _gameFactory.Reset();
        }
    }
}