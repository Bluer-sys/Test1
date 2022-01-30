using System.Collections.Generic;
using System.Threading.Tasks;
using SaveLoad;
using Services;
using States;
using UI.Elements;
using UnityEngine;
using Zenject;

namespace UI.UIFactory
{
    public class UIGameFactory : IUIGameFactory
    {
        private IGameStateMachine _gameStateMachine;
        private IAssetProvider _assetProvider;

        private GameObject _uiRoot;
        private PlayerHUD _playerHUD;

        public List<ISaved> ProgressWriters { get; } = new List<ISaved>();
        public List<ILoadable> ProgressWatchers { get; } = new List<ILoadable>();

        [Inject]
        private void Construct (IGameStateMachine gameStateMachine, IAssetProvider assetProvider)
        {
            _gameStateMachine = gameStateMachine;
            _assetProvider = assetProvider;
        }

        public async Task<GameObject> CreateUIRoot()
        {
            GameObject uiRootObject = await _assetProvider.Instantiate(AssetAddress.UIRoot);
            _uiRoot = uiRootObject;

            return uiRootObject;
        }
        
        public async Task<MainMenu> CreateMainMenu()
        {
            GameObject mainMenuObject = await _assetProvider.Instantiate(AssetAddress.MainMenu, _uiRoot.transform);

            MainMenu mainMenu = mainMenuObject.GetComponent<MainMenu>();
            mainMenu.Construct(_gameStateMachine);
            
            return mainMenu;
        }

        public async Task<ScoreBoard> CreateScoreBoard()
        {
            GameObject scoreBoardObject = await InstantiateRegistered();

            ScoreBoard scoreBoard = scoreBoardObject.GetComponent<ScoreBoard>();
            scoreBoard.Construct(_gameStateMachine, _assetProvider);

            return scoreBoard;
        }

        public async Task<PlayerHUD> CreatePlayerHUD()
        {
            GameObject hudObject = await _assetProvider.Instantiate(AssetAddress.HUD);

            PlayerHUD playerHUD = hudObject.GetComponent<PlayerHUD>();

            _playerHUD = playerHUD;
            return playerHUD;
        }

        public void Reset()
        {
            Object.Destroy(_playerHUD.gameObject);

            ProgressWatchers.Clear();
            ProgressWriters.Clear();
        }

        private async Task<GameObject> InstantiateRegistered()
        {
            GameObject scoreBoardObject = await _assetProvider.Instantiate(AssetAddress.ScoreBoard, _uiRoot.transform);

            foreach (ILoadable watcher in scoreBoardObject.GetComponentsInChildren<ILoadable>())
            {
                ProgressWatchers.Add(watcher);
            }

            foreach (ISaved writer in scoreBoardObject.GetComponentsInChildren<ISaved>())
            {
                ProgressWriters.Add(writer);
            }

            return scoreBoardObject;
        }
    }
}