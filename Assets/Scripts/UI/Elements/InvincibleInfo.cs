using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements
{
    [RequireComponent(typeof(Image))]
    public class InvincibleInfo : MonoBehaviour
    {
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void ChangeFilling(float max, float current)
        {
            _image.fillAmount = (1 - current / max);
        }
    }
}
