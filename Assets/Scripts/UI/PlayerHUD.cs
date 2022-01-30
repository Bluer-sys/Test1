using Player;
using UI.Elements;
using UnityEngine;

namespace UI
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] private InvincibleInfo _invincibleInfo;
        [SerializeField] private HpBar _hpBar;
        [SerializeField] private ScoreBar _scoreBar;
        
        private PlayerInvincible _playerInvincible;
        private PlayerHealth _playerHealth;
        private PlayerScore _playerScore;

        public void Construct(PlayerInvincible playerInvincible, PlayerHealth playerHealth, PlayerScore playerScore)
        {
            _playerInvincible = playerInvincible;
            _playerHealth = playerHealth;
            _playerScore = playerScore;
            
            _playerInvincible.ElapsedTimeChanged += UpdateInvincibleInfo;
            _playerHealth.HealthChanged += UpdateHealthBar;
            _playerScore.ScoreChanged += UpdateScoreBar;
        }

        private void OnDestroy()
        {
            _playerInvincible.ElapsedTimeChanged -= UpdateInvincibleInfo;
            _playerHealth.HealthChanged -= UpdateHealthBar;
            _playerScore.ScoreChanged -= UpdateScoreBar;
        }

        private void UpdateInvincibleInfo(float max, float current)
        {
            _invincibleInfo.ChangeFilling(max, current);
        }

        private void UpdateHealthBar(int oldHp, int newHp)
        {
            int difference = oldHp - newHp;

            if (difference > 0)
            {
                for (int i = 0; i < Mathf.Abs(difference); i++)
                {
                    _hpBar.RemoveHp();
                }
            }
            else
            {
                for (int i = 0; i < Mathf.Abs(difference); i++)
                {
                    _hpBar.AddHp();
                }
            }
        }
        
        private void UpdateScoreBar(int value)
        {
            _scoreBar.ChangeScoreText(value);
        }
    }
}
