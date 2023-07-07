using UI.View;
using UnityEngine;

namespace UI.Presenter
{
    public abstract class CarStatePresenter : MonoBehaviour
    {
        [SerializeField] protected Driving.Car Car;
        [SerializeField] private ProgressBar _progressBar;

        private void Start()
        {
            Initialize();
            Subscribe();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        protected abstract void Initialize();
        protected abstract void Subscribe();
        protected abstract void Unsubscribe();

        protected void UpdateProgress(float value, float maxValue)
        {
            var progress = value / maxValue;
            _progressBar.SetProgress(progress);
        }
    }
}