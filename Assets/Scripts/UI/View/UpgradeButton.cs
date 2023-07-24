using System;
using UnityEngine;
using UnityEngine.UI;
using Upgrade;

namespace UI.View
{
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private UpgradableParameterConfig _config;

        public event Action<UpgradableParameterConfig> Clicked;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            Clicked?.Invoke(_config);
        }
    }
}