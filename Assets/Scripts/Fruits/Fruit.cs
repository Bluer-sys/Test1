using System;
using Enemy;
using Player;
using UnityEngine;

namespace Fruits
{
    [RequireComponent(typeof(TriggerObserver),typeof(SpriteRenderer))]
    public class Fruit : MonoBehaviour
    {
        private TriggerObserver _triggerObserver;

        public bool PickedUp { get;  set; }
        public SpriteRenderer SpriteRenderer { get; set; }
        public int FruitCost { get; set; }

        public event Action<Fruit> FruitPickedUp;

        private void Awake()
        {
            _triggerObserver = GetComponent<TriggerObserver>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
            
            _triggerObserver.TriggerEntered += OnTriggerEntered;
        }

        private void OnDestroy()
        {
            _triggerObserver.TriggerEntered -= OnTriggerEntered;
        }

        private void OnTriggerEntered(PlayerHealth playerComponent)
        {
            if(PickedUp)
                return;

            PickedUp = true;
            
            AddScore(playerComponent);
            
            FruitPickedUp?.Invoke(this);
        }

        private void AddScore(PlayerHealth playerComponent)
        {
            PlayerScore playerScore = playerComponent.GetComponent<PlayerScore>();
            playerScore.AddScore(FruitCost);
        }
    }
}