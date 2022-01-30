using TMPro;
using UnityEngine;

namespace UI.Elements
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreBar : MonoBehaviour
    {
        private TMP_Text _scoreText;

        private void Awake()
        {
            _scoreText = GetComponent<TMP_Text>();
        }

        public void ChangeScoreText(int value)
        {
            _scoreText.text = value.ToString();
        }
    }
}