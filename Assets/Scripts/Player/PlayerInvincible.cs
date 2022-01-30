using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerInvincible : MonoBehaviour
    {
        [SerializeField] private float _invincibleDuration;
        
        private Collider2D _collider;
        private WaitForSeconds _waitForSeconds;
        private float _elapsedTime;

        public event Action<float,float> ElapsedTimeChanged;

        private void OnValidate()
        {
            if (_invincibleDuration < 0)
                _invincibleDuration = 0;
        }

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _collider.enabled = false;
            
            _waitForSeconds = new WaitForSeconds(0.1f);
        }

        private void Start()
        {
            StartCoroutine(InvincibleTimer());
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
        }

        private IEnumerator InvincibleTimer()
        {
            while (_elapsedTime < _invincibleDuration)
            {
                yield return _waitForSeconds;
                ElapsedTimeChanged?.Invoke(_invincibleDuration, _elapsedTime);
            }
            
            _collider.enabled = true;
        }
    }
}