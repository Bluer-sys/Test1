using System.Collections.Generic;
using System.Threading.Tasks;
using Enemy;
using Fruits;
using Player;
using SaveLoad;
using Services.Input;
using Services.Random;
using States;
using UI.Services;
using UnityEngine;
using Zenject;

namespace Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private IAssetProvider _assetProvider;
        private IInputService _inputService;
        private IRandomService _randomService;
        private IWindowService _windowService;

        private GameObject _player;
        private GameObject _enemyContainer;
        private GameObject _fruitSpawner;

        public List<ISaved> ProgressWriters { get; } = new List<ISaved>();
        public List<ILoadable> ProgressWatchers { get; } = new List<ILoadable>();

        [Inject]
        private void Construct(IAssetProvider assetProvider, IInputService inputService, IRandomService randomService,
            IWindowService windowService, IGameStateMachine gameStateMachine)
        {
            _assetProvider = assetProvider;
            _inputService = inputService;
            _randomService = randomService;
            _windowService = windowService;
        }
        
        public async Task<GameObject> CreatePlayer(Vector3 position)
        {
            GameObject playerObject = await InstantiateRegistered(position);

            PlayerInput playerInput = playerObject.GetComponent<PlayerInput>();
            playerInput.Construct(_inputService);
            
            PlayerDeath playerDeath = playerObject.GetComponent<PlayerDeath>();
            playerDeath.Construct(_windowService);

            _player = playerObject;
            return playerObject;
        }

        public async void CreateGround()
        {
            await _assetProvider.Instantiate(AssetAddress.Background, at: Vector3.zero);
        }

        public async Task<GameObject> CreateEnemy(Vector3 position, Transform parent)
        {
            GameObject enemyGameObject = await _assetProvider.Instantiate(AssetAddress.Enemy, position, parent);

            EnemyMove enemyMove = enemyGameObject.GetComponent<EnemyMove>();
            enemyMove.Construct(_randomService);

            return enemyGameObject;
        }

        public async Task<GameObject> CreateEnemyContainer()
        {
            GameObject enemyContainer = await _assetProvider.Instantiate(AssetAddress.EnemyContainer);

            _enemyContainer = enemyContainer;
            return enemyContainer;
        }

        public async Task<Fruit> CreateFruit(Transform parent)
        {
            GameObject fruitGameObject = await _assetProvider.Instantiate(AssetAddress.Fruit, parent);
            
            Fruit fruit = fruitGameObject.GetComponent<Fruit>();
            return fruit;
        }

        public async Task<GameObject> CreateFruitSpawner()
        {
            GameObject fruitSpawnerObject = await _assetProvider.Instantiate(AssetAddress.FruitSpawner);

            FruitSpawner fruitSpawner = fruitSpawnerObject.GetComponent<FruitSpawner>();
            fruitSpawner.Construct(_randomService);

            _fruitSpawner = fruitSpawnerObject;
            return fruitSpawnerObject;
        }


        public void Reset()
        {
            Object.Destroy(_player);
            Object.Destroy(_enemyContainer);
            Object.Destroy(_fruitSpawner); 
            
            ProgressWatchers.Clear();
            ProgressWriters.Clear();
        }

        private async Task<GameObject> InstantiateRegistered(Vector3 position)
        {
            GameObject playerObject = await _assetProvider.Instantiate(AssetAddress.Player, at: position);

            foreach (ISaved writer in playerObject.GetComponentsInChildren<ISaved>())
            {
                ProgressWriters.Add(writer);
            }

            foreach (ILoadable watcher in playerObject.GetComponentsInChildren<ILoadable>())
            {
                ProgressWatchers.Add(watcher);
            }

            return playerObject;
        }
    }
}