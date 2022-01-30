using Data;

namespace Services.Progress
{
    public interface IPersistentProgress
    {
        PlayerProgress Progress { get; set; }
    }
}