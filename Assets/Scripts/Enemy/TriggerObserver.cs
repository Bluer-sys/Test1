using System;
using Player;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<PlayerHealth> TriggerEntered;
        public event Action<PlayerHealth> TriggerExited;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerHealth playerHealth))
            {
                TriggerEntered?.Invoke(playerHealth);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerHealth playerHealth))
            {
                TriggerExited?.Invoke(playerHealth);
            }
        }
    }
}
