using System.Collections.Generic;
using System.Threading.Tasks;
using Fruits;
using SaveLoad;
using UnityEngine;

namespace Services.Factory
{
    public interface IGameFactory
    {
        Task<GameObject> CreatePlayer(Vector3 position);
        void CreateGround();
        Task<GameObject> CreateEnemy(Vector3 position, Transform parent);
        Task<GameObject> CreateEnemyContainer();
        Task<Fruit> CreateFruit(Transform parent);
        Task<GameObject> CreateFruitSpawner();
        void Reset();
        List<ISaved> ProgressWriters { get; }
        List<ILoadable> ProgressWatchers { get; }
    }
}