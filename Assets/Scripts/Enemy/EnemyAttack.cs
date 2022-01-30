using System.Collections;
using Player;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(TriggerObserver))]
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private int _damage;

        private TriggerObserver _triggerObserver;

        private bool _isInTrigger;
        private Coroutine _attackCoroutine;
        private WaitForSeconds _waitForDelay;

        private void Awake()
        {
            _triggerObserver = GetComponent<TriggerObserver>();
        }

        private void Start()
        {
            _triggerObserver.TriggerEntered += OnTriggerEntered;
            _triggerObserver.TriggerExited += OnTriggerExited;

            _waitForDelay = new WaitForSeconds(2.0f);
        }

        private void OnDestroy()
        {
            _triggerObserver.TriggerEntered -= OnTriggerEntered;
            _triggerObserver.TriggerExited -= OnTriggerExited;
        }

        private void OnTriggerEntered(PlayerHealth playerHealth)
        {
            if (_isInTrigger)
                return;

            _isInTrigger = true;

            if (_attackCoroutine == null)
            {
                _attackCoroutine = StartCoroutine(AttackWithDelay(playerHealth));
            }
        }

        private void OnTriggerExited(PlayerHealth playerHealth)
        {
            if (!_isInTrigger)
                return;

            _isInTrigger = false;

            if (_attackCoroutine != null)
            {
                StopCoroutine(_attackCoroutine);
                _attackCoroutine = null;
            }
        }

        private IEnumerator AttackWithDelay(PlayerHealth playerHealth)
        {
            while (_isInTrigger)
            {
                playerHealth.TakeDamage(_damage);
                yield return _waitForDelay;
            }
        }
    }
}