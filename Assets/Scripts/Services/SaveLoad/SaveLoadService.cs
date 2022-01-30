using Data;
using SaveLoad;
using Services.Factory;
using Services.Progress;
using UI.UIFactory;
using UnityEngine;
using Zenject;

namespace Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        
        private IUIGameFactory _uiFactory;
        private IPersistentProgress _persistentProgress;
        private IGameFactory _gameFactory;

        [Inject]
        private void Construct(IPersistentProgress persistentProgress, IUIGameFactory uiFactory, IGameFactory gameFactory)
        {
            _uiFactory = uiFactory;
            _persistentProgress = persistentProgress;
            _gameFactory = gameFactory;
        }
        
        public void SaveProgress()
        {
            foreach (ISaved writer in _uiFactory.ProgressWriters)
            {
                writer.SaveProgress(_persistentProgress.Progress);
            }
            
            foreach (ISaved writer in _gameFactory.ProgressWriters)
            {
                writer.SaveProgress(_persistentProgress.Progress);
            }
            
            PlayerPrefs.SetString(ProgressKey, _persistentProgress.Progress.ToSerialized());
        }

        public PlayerProgress LoadProgress()
        {
            PlayerProgress playerProgress = PlayerPrefs.GetString(ProgressKey).ToDeserialized<PlayerProgress>();
            return playerProgress;
        }

        public void InformProgressWatchers()
        {
            foreach (ILoadable watcher in _uiFactory.ProgressWatchers)
            {
                watcher.LoadProgress(_persistentProgress.Progress);
            }
            
            foreach (ILoadable watcher in _gameFactory.ProgressWatchers)
            {
                watcher.LoadProgress(_persistentProgress.Progress);
            }
        }
    }
}