using System.Collections.Generic;
using System.Threading.Tasks;
using SaveLoad;
using Services;
using UI.Elements;
using UnityEngine;

namespace UI.UIFactory
{
    public interface IUIGameFactory : IService
    {
        Task<GameObject> CreateUIRoot();
        Task<MainMenu> CreateMainMenu();
        Task<PlayerHUD> CreatePlayerHUD();
        Task<ScoreBoard> CreateScoreBoard();
        void Reset();
        List<ISaved> ProgressWriters { get; }
        List<ILoadable> ProgressWatchers { get; }
    }
}