using Data;

namespace Services.Progress
{
    public class PersistentProgress : IPersistentProgress
    {
        public PlayerProgress Progress { get; set; }
    }
}