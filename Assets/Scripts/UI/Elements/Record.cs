using TMPro;
using UnityEngine;

namespace UI.Elements
{
    [RequireComponent(typeof(TMP_Text))]
    public class Record : MonoBehaviour
    {
        private TMP_Text _recordText;

        private void Awake()
        {
            _recordText = GetComponent<TMP_Text>();
        }

        public void SetRecord(int number, int score)
        {
            _recordText.text = number + ". " + score;
        }
    }
}