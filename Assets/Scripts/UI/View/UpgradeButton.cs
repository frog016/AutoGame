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

        public UpgradableParameterConfig Config { get; private set; }
        public event Action<UpgradableParameterConfig> Clicked;

        public void Initialize(UpgradableParameterConfig config)
        {
            Config = config;
        }

        private void Start()
        {
            _parameterNameText.text = Config.Name;
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDestroy()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        public void SetProgress(int currentLevel)
        {
            _upgradeProgressText.text = $"{currentLevel} / {Config.MaxUpgradeLevel}";
        }

        private void OnButtonClick()
        {
            Clicked?.Invoke(Config);
        }
    }
}