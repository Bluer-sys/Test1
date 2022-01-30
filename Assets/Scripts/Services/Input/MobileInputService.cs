using UnityEngine;

namespace Services.Input
{
    public class MobileInputService : IInputService
    {
        public Vector2 GetMovingPosition()
        {
            if (UnityEngine.Input.touchCount != 0)
            {
                Touch touch = UnityEngine.Input.GetTouch(0);

                return touch.position;
            }
            
            return Vector2.zero;
        }
    }
}