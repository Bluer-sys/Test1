using Services.Input;
using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        private IInputService _inputService;

        public Vector2 MovePosition { get; private set; }

        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            MovePosition = _inputService.GetMovingPosition();
        }
    }
}