namespace Services.StaticData
{
    public interface IStaticDataService
    {
        void Load();
        int EnemyCount { get; }
    }
}