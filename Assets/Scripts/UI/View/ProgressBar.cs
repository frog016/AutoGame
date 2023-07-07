using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _filledImage;

        public void SetProgress(float value)
        {
            _filledImage.fillAmount = value;
        }
    }
}
