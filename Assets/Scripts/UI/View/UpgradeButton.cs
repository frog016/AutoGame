using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Upgrade;

namespace UI.View
{
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _parameterNameText;
        [SerializeField] private TextMeshProUGUI _upgradeProgressText;

        public event Action<UpgradableParameterConfig> Clicked;
        
        private UpgradableParameterConfig _config;

        public void Initialize(UpgradableParameterConfig config)
        {
            _config = config;
        }

        private void Start()
        {
            _parameterNameText.text = _config.Name;
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDestroy()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        public void SetProgress(int currentLevel)
        {
            _upgradeProgressText.text = $"{currentLevel} / {_config.MaxUpgradeLevel}";
        }

        private void OnButtonClick()
        {
            Clicked?.Invoke(_config);
        }
    }
}