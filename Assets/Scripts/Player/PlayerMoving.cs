using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMoving : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Camera _mainCamera;
        private PlayerInput _playerInput;

        private Vector2 _worldMovePosition;

        private void OnValidate()
        {
            if (_speed < 0)
                _speed = 0;
        }

        private void Awake()
        {
            _mainCamera = Camera.main;
            _playerInput = GetComponent<PlayerInput>();

            _worldMovePosition = transform.position;
        }

        private void Update()
        {
            if (!InputVectorZero())
            {
                UpdateWorldPosition();
            }

            Move();
        }

        private void Move()
        {
            transform.position =
                Vector2.MoveTowards(
                    transform.position,
                    _worldMovePosition,
                    _speed * Time.deltaTime);
        }

        private bool InputVectorZero() =>
            _playerInput.MovePosition == Vector2.zero;

        private void UpdateWorldPosition() =>
            _worldMovePosition = _mainCamera.ScreenToWorldPoint(_playerInput.MovePosition);
    }
}