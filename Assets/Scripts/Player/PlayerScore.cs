using System;
using Data;
using SaveLoad;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerDeath))]
    public class PlayerScore : MonoBehaviour, ISaved
    { 
        private int _currentScore;

        public event Action<int> ScoreChanged;

        public void Initialize()
        {
            ScoreChanged?.Invoke(_currentScore);
        }

        public void AddScore(int value)
        {
            _currentScore += value;
            ScoreChanged?.Invoke(_currentScore);
        }

        public void SaveProgress(PlayerProgress progress)
        {
            progress.RecordsData.Records.Add(_currentScore);
        }
    }
}