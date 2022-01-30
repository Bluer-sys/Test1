using UnityEngine;

namespace Services.Random
{
    public interface IRandomService
    {
        void Initialize();
        Vector2 RandomPosition();
        int RandomInt(int min, int max);
        Color RandomColor();
    }
}