using States;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        private IGameStateMachine _gameStateMachine;
        
        public void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayClicked);
            _exitButton.onClick.AddListener(OnExitClicked);
        }

        private void OnEnable()
        {
            SwitchButtons(true);
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveListener(OnPlayClicked);
            _exitButton.onClick.RemoveListener(OnExitClicked);
        }

        private void OnPlayClicked()
        {
            SwitchButtons(false);
            
            _gameStateMachine.Enter<LoadLevelState, MainMenu>(this);
            
            Destroy(gameObject);
        }

        private void OnExitClicked()
        {
            SwitchButtons(false);
            
            Application.Quit();
        }

        private void SwitchButtons(bool isActive)
        {
            _playButton.enabled = isActive;
            _exitButton.enabled = isActive;
        }
    }
}