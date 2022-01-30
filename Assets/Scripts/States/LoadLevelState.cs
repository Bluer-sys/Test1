using System;
using System.Threading.Tasks;
using Fruits;
using Player;
using Services.Factory;
using Services.Random;
using Services.StaticData;
using UI;
using UI.Elements;
using UI.UIFactory;
using UnityEngine;

namespace States
{
    public class LoadLevelState : IPayloadedState<MainMenu>
    {
        private readonly IUIGameFactory _uiFactory;
        private readonly IGameFactory _gameFactory;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticDataService;
        private readonly IRandomService _randomService;
        
        public LoadLevelState(IGameStateMachine gameStateMachine, IUIGameFactory uiFactory, IGameFactory gameFactory, IStaticDataService staticDataService, IRandomService randomService)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
            _gameFactory = gameFactory;
            _staticDataService = staticDataService;
            _randomService = randomService;
        }

        public void Enter(MainMenu mainMenu)
        {
            InitWorld(onInit: EnterGameLoopState);
        }

        public void Exit()
        {
        }

        private async void InitWorld(Action onInit)
        {
            GameObject player = await InitPlayer();
            await InitHUD(player);
            await InitEnemies();
            await InitFruit();
            
            onInit.Invoke();
        }

        private async Task InitFruit()
        {
            GameObject fruitSpawnerObject = await _gameFactory.CreateFruitSpawner();
            FruitSpawner fruitSpawner = fruitSpawnerObject.GetComponent<FruitSpawner>();
            
            for (int i = 0; i < fruitSpawner.FruitCount; i++)
            {
                Fruit fruit = await _gameFactory.CreateFruit(fruitSpawner.transform);
                
                fruit.FruitPickedUp += fruitSpawner.SpawnFruit;
                
                fruitSpawner.FruitPool.Add(fruit);
            }

            fruitSpawner.InitAllFruits();
        }

        private async Task InitHUD(GameObject player)
        {
            PlayerHUD playerHUD = await _uiFactory.CreatePlayerHUD();
            
            playerHUD.Construct(
                player.GetComponent<PlayerInvincible>(),
                player.GetComponent<PlayerHealth>(),
                player.GetComponent<PlayerScore>());
            
            player.GetComponent<PlayerHealth>().Initialize();
            player.GetComponent<PlayerScore>().Initialize();
        }

        private async Task<GameObject> InitPlayer()
        {
            GameObject playerObject = await _gameFactory.CreatePlayer(Vector3.zero);
            
            return playerObject;
        }

        private async Task InitEnemies()
        {
            GameObject enemyContainer = await _gameFactory.CreateEnemyContainer();
            
            for (int i = 0; i < _staticDataService.EnemyCount; i++)
            {
                GameObject enemy = await _gameFactory.CreateEnemy(_randomService.RandomPosition(), enemyContainer.transform);
            }
        }

        private void EnterGameLoopState() =>
            _gameStateMachine.Enter<GameLoopState>();
    }
}
