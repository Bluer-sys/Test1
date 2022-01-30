using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/EnemyData")]
    public class EnemyStaticData : ScriptableObject
    {
        public int EnemyCount;
    }
}