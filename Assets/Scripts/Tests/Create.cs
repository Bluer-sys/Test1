using Player;
using UnityEngine;

namespace Tests
{
    public static class Create
    {
        public static PlayerHealth PlayerHealth()
        {
            return new GameObject().AddComponent<PlayerHealth>();
        }
    }
}