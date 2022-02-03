using Services.Random;
using UnityEngine;

namespace Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private float _timeToChangeMovePosition;
        [SerializeField] private float _speed;

        private IRandomService _randomService;

        private float _elapsedTime;
        private Vector2 _movePosition;

        public Vector2 MovePosition => _movePosition;
        public IRandomService RandomService {
            set => _randomService = value;
        }

        public void Construct(IRandomService randomService)
        {
            _randomService = randomService;
        }

        private void Start()
        {
            _elapsedTime = _timeToChangeMovePosition;
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _timeToChangeMovePosition)
            {
                SetNewPosition();
            }

            MoveToPosition();
        }

        public void SetNewPosition()
        {
            _movePosition = _randomService.RandomPosition();
            _elapsedTime = 0;
        }

        private void MoveToPosition() =>
            transform.position = Vector3.MoveTowards(transform.position, _movePosition, _speed * Time.deltaTime);
    }
}