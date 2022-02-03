using System;
using System.Threading.Tasks;
using Services;
using Services.Ads;
using Services.Factory;
using Services.Random;
using Services.StaticData;
using UI.UIFactory;

namespace States
{
    public class BootstrapState : IState
    {
        private readonly IUIGameFactory _uiGameFactory;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;
        private readonly IRandomService _randomService;
        private readonly IGameFactory _gameFactory;
        private readonly IAdsService _adsService;
        private readonly IGameStateMachine _gameStateMachine;

        public BootstrapState(IGameStateMachine gameStateMachine, IUIGameFactory uiGameFactory,
            IAssetProvider assetProvider, IStaticDataService staticDataService, IRandomService randomService, IGameFactory gameFactory, IAdsService adsService)
        {
            _uiGameFactory = uiGameFactory;
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
            _randomService = randomService;
            _gameFactory = gameFactory;
            _adsService = adsService;
            _gameStateMachine = gameStateMachine;
        }
        
        public void Enter()
        {
            InitServices();
            InitGameObjects();
            InitUI(onInit: EnterNextState);
        }

        public void Exit()
        {
        }

        private void InitServices()
        {
            _assetProvider.Initialize();
            _staticDataService.Load();
            _randomService.Initialize();
            
            _adsService.Initialize();
        }

        private async  void InitUI(Action onInit)
        {
            await InitUIRoot();

            onInit.Invoke();
        }

        private async Task InitUIRoot()
        {
            await _uiGameFactory.CreateUIRoot();
        }

        private void InitGameObjects()
        {
            _gameFactory.CreateGround();
        }

        private void EnterNextState() =>
            _gameStateMachine.Enter<LoadProgressState>();
    }
}