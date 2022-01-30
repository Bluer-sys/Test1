using System.Collections.Generic;
using Services.Random;
using UnityEngine;

namespace Fruits
{
    public class FruitSpawner : MonoBehaviour
    {
        [SerializeField] private int _fruitCount;
        [SerializeField] private int _maxFruitCost;
        [SerializeField] private int _minFruitCost;

        private IRandomService _randomService;

        public List<Fruit> FruitPool { get; } = new List<Fruit>();
        public int FruitCount => _fruitCount;

        public void Construct(IRandomService randomService)
        {
            _randomService = randomService;
        }
        
        private void OnValidate()
        {
            _maxFruitCost = Mathf.Abs(_maxFruitCost);
            _minFruitCost = Mathf.Abs(_minFruitCost);
            
            if (_minFruitCost > _maxFruitCost)
                _minFruitCost = _maxFruitCost;
        }

        private void OnDestroy()
        {
            DescribeFruits();
        }

        private void DescribeFruits()
        {
            for (int i = 0; i < FruitPool.Count; i++)
            {
                FruitPool[i].FruitPickedUp -= SpawnFruit;
            }            
        }

        public void InitAllFruits()
        {
            for (int i = 0; i < FruitPool.Count; i++)
            {
                SpawnFruit(FruitPool[i]);
            }
        }

        public void SpawnFruit(Fruit fruit)
        {
            SetRandomParameters(fruit);
            
            fruit.PickedUp = false;
        }

        private void SetRandomParameters(Fruit fruit)
        {
            fruit.FruitCost = _randomService.RandomInt(_minFruitCost, _maxFruitCost);
            fruit.transform.position = _randomService.RandomPosition();
            fruit.SpriteRenderer.color = _randomService.RandomColor();
        }
    }
}