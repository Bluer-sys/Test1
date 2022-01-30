using Data;

namespace Services.SaveLoad
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
        void InformProgressWatchers();
    }
}