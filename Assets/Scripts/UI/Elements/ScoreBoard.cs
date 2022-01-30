using System.Collections.Generic;
using Data;
using SaveLoad;
using Services;
using States;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements
{
    public class ScoreBoard : MonoBehaviour, ILoadable
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Transform _recordContainer;

        private IGameStateMachine _gameStateMachine;
        private IAssetProvider _assetProvider;

        private readonly List<int> _records = new List<int>();
        
        public void Construct(IGameStateMachine gameStateMachine, IAssetProvider assetProvider)
        {
            _gameStateMachine = gameStateMachine;
            _assetProvider = assetProvider;
        }

        private void Awake()
        {
            _continueButton.onClick.AddListener(RestartGame);
        }

        private void OnEnable()
        {
            _continueButton.interactable = true;
        }

        private void OnDestroy()
        {
            _continueButton.onClick.RemoveListener(RestartGame);
        }

        public async void SetRecords()
        {
            for (int i = 0; i < _records.Count; i++)
            {
                GameObject record = await _assetProvider.Instantiate(AssetAddress.Record, _recordContainer);
                
                record
                    .GetComponent<Record>()
                    .SetRecord(i + 1, _records[i]);
            }
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if(progress.RecordsData.Records.Count == 0)
                return;

            foreach (var record in progress.RecordsData.Records)
            {
                _records.Add(record);
            }
        }

        private void RestartGame()
        {
            HideScoreBoard();

            _gameStateMachine.Enter<MainMenuState>();
        }

        private void HideScoreBoard()
        {
            _continueButton.enabled = false;
            
            Destroy(gameObject);
        }
    }
}