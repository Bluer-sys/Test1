using UI.Services;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerHealth), typeof(PlayerMoving), typeof(Collider2D))]
    public class PlayerDeath : MonoBehaviour
    {
        private IWindowService _windowService;

        private PlayerHealth _playerHealth;
        private bool _isDead;

        public void Construct(IWindowService windowService)
        {
            _windowService = windowService;
        }

        private void Awake()
        {
            _playerHealth = GetComponent<PlayerHealth>();

            _playerHealth.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged(int odlHp, int newHp)
        {
            if (newHp <= 0)
            {
                if (!_isDead)
                {
                    SetDeath();
                }
            }
        }

        private void SetDeath()
        {
            _isDead = true;
            Destroy(gameObject);

            _playerHealth.HealthChanged -= OnHealthChanged;

            _windowService.Open(WindowId.ScoreBoard);
        }
    }
}