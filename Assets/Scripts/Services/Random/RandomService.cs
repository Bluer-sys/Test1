using UnityEngine;

namespace Services.Random
{
    public class RandomService : IRandomService
    {
        private Camera _mainCamera;
        
        public void Initialize()
        {
            _mainCamera = Camera.main;
        }
        
        public Vector2 RandomPosition()
        {
            Vector2 randomVector = new Vector2(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
            
            Vector2 randomPosition = _mainCamera.ViewportToWorldPoint(randomVector);
            return randomPosition;
        }

        public int RandomInt(int min, int max) => 
            UnityEngine.Random.Range(min, max);

        public Color RandomColor()
        {
            return UnityEngine.Random.ColorHSV();
        }
    }
}