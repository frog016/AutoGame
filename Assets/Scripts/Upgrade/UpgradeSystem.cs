using Driving;
using System;
using System.Collections.Generic;

namespace Upgrade
{
    public class UpgradeSystem
    {
        private readonly CarStatsConfig _carStats;
        private readonly Dictionary<UpgradableParameterConfig, int> _parametersStatus;

        public UpgradeSystem(CarStatsConfig config)
        {
            _carStats = config;
            _parametersStatus = new Dictionary<UpgradableParameterConfig, int>();
        }

        public void Upgrade(UpgradableParameterConfig config, Action<CarStatsConfig, float> upgradeAction)
        {
            if (IsLevelMax(config))
                return;

            upgradeAction.Invoke(_carStats, config.Factor);
        }

        private bool IsLevelMax(UpgradableParameterConfig config)
        {
            var level = 0;
            if (_parametersStatus.ContainsKey(config))
                level = _parametersStatus[config];
            else
                _parametersStatus.Add(config, 0);

            var nextLevel = level + 1;
            return nextLevel > config.MaxUpgradeLevel;
        }
    }
}