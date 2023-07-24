using System;
using System.Collections.Generic;
using System.Linq;
using Driving;
using UI.View;
using UnityEngine;
using Upgrade;

namespace UI.Presenter
{
    public class UpgradeSystemPresenter : MonoBehaviour
    {
        [SerializeField] private UpgradeButton[] _buttons;
        
        private UpgradeSystem _upgradeSystem;

        public void Initialize(CarStatsConfig config)
        {
            _upgradeSystem = new UpgradeSystem(config);

            var upgradeActions = GetActions();
            var buttonActionPair = _buttons.Zip(upgradeActions, Tuple.Create);

            foreach (var (button, action) in buttonActionPair)
            {
                button.Clicked += UpgradeOnClick;

                void UpgradeOnClick(UpgradableParameterConfig parameter)
                {
                    _upgradeSystem.Upgrade(parameter, action);

                    parameter.Upgrade();
                    button.SetProgress(parameter.CurrentLevel);
                }
            }
        }

        private static IEnumerable<Action<CarStatsConfig, float>> GetActions()
        {
            yield return (config, factor) => config.Acceleration *= factor;
            yield return (config, factor) => config.MaxSpeed *= factor;
            yield return (config, factor) => config.FuelCapacity *= factor;
            yield return (config, factor) => config.FuelConsumption *= factor;
            yield return (config, factor) => config.MaxHealth = Mathf.RoundToInt(config.MaxHealth * factor);
        }
    }
}