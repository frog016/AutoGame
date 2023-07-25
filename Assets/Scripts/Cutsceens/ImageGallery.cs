using UnityEngine;
using UnityEngine.UI;

namespace Cutsceens
{
    public class ImageGallery : MonoBehaviour
    {
        [SerializeField] private Image _frameDisplay;
        [SerializeField] private Sprite[] _frames;

        private int _currentFrame;

        private void OnEnable()
        {
            _frameDisplay.sprite = _frames[0];
        }

        public void Next()
        {
            var nextFrameIndex = ++_currentFrame % _frames.Length;
            var frame = _frames[nextFrameIndex];
            _frameDisplay.sprite = frame;
        }
    }
}
