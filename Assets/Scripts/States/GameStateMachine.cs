using System;
using System.Collections.Generic;
using Services;
using Services.Factory;
using Services.Progress;
using Services.Random;
using Services.SaveLoad;
using Services.StaticData;
using UI.Services;
using UI.UIFactory;
using Zenject;

namespace States
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;

        [Inject]
        private void Construct(IUIGameFactory uiGameFactory, IGameFactory gameFactory, IAssetProvider assetProvider,
            IStaticDataService staticDataService, IRandomService randomService, IWindowService windowService, ISaveLoadService saveLoadService, IPersistentProgress persistentProgress)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, uiGameFactory, assetProvider, staticDataService, randomService, gameFactory),
                [typeof(LoadProgressState)] = new LoadProgressState(this, persistentProgress, saveLoadService),
                [typeof(MainMenuState)] = new MainMenuState(windowService),
                [typeof(LoadLevelState)] = new LoadLevelState(this, uiGameFactory, gameFactory, staticDataService, randomService),
                [typeof(GameLoopState)] = new GameLoopState(saveLoadService),
                [typeof(ScoreBoardState)] = new ScoreBoardState(uiGameFactory, gameFactory, saveLoadService),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            _currentState?.Exit();

            TState newState = GetState<TState>();
            _currentState = newState;
            
            newState.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            _currentState?.Exit();

            TState newState = GetState<TState>();
            _currentState = newState;
            
            newState.Enter(payload);
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}