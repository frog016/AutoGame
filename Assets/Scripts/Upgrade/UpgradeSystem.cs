using Driving;
using System;

namespace Upgrade
{
    public class UpgradeSystem
    {
        private readonly CarStatsConfig _carStats;

        public UpgradeSystem(CarStatsConfig config)
        {
            _carStats = config;
        }

        public void Upgrade(UpgradableParameterConfig config, Action<CarStatsConfig, float> upgradeAction)
        {
            if (IsLevelMax(config))
                return;

            upgradeAction.Invoke(_carStats, config.Factor);
        }

        private static bool IsLevelMax(UpgradableParameterConfig config)
        {
            var nextLevel = config.CurrentLevel + 1;
            return nextLevel > config.MaxUpgradeLevel;
        }
    }
}