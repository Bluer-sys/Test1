using System;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        
        private int _currentHealth;

        public event Action<int, int> HealthChanged;

        public int CurrentHealth => _currentHealth;
        
        public void Initialize()
        {
            HealthChanged?.Invoke(0, _maxHealth);
        }
        
        private void OnValidate()
        {
            if (_maxHealth < 1)
                _maxHealth = 1;
        }

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int damage)
        {
            int newHp = _currentHealth - damage;
            
            HealthChanged?.Invoke(_currentHealth, newHp);
            
            _currentHealth = newHp;
        }
    }
}
