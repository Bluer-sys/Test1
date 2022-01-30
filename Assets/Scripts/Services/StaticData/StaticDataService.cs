using StaticData;
using UnityEngine;

namespace Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataEnemy = "StaticData/Enemy/EnemyData";

        public int EnemyCount { get; private set; }

        public void Load()
        {
            EnemyCount = Resources.Load<EnemyStaticData>(StaticDataEnemy).EnemyCount;
        }
    }
}