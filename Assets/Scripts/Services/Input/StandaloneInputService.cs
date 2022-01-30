using UnityEngine;

namespace Services.Input
{
    public class StandaloneInputService : IInputService
    {
        public Vector2 GetMovingPosition()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                return UnityEngine.Input.mousePosition;
            }
            
            return Vector2.zero;
        }
    }
}