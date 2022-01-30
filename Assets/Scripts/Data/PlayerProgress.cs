using System;

namespace Data
{
    [Serializable]
    public class PlayerProgress
    {
        public RecordsData RecordsData;

        public PlayerProgress()
        {
            RecordsData = new RecordsData();
        }
    }
}