using Driving;
using System;
using UnityEngine;

namespace Upgrade
{
    public class UpgradeSystem
    {
        private readonly CarStatsConfig _carStats;

        private const string CostKey = "CoinsAmount";

        public UpgradeSystem(CarStatsConfig config)
        {
            _carStats = config;
        }

        public void Upgrade(UpgradableParameterConfig config, Action<CarStatsConfig, float> upgradeAction)
        {
            if (IsLevelMax(config) || IsEnough(config.Cost) == false)
                return;

            upgradeAction.Invoke(_carStats, config.Factor);
            var value = PlayerPrefs.GetInt(CostKey) - config.Cost;
            PlayerPrefs.SetInt(CostKey, value);
        }

        private static bool IsLevelMax(UpgradableParameterConfig config)
        {
            var nextLevel = config.CurrentLevel + 1;
            return nextLevel > config.MaxUpgradeLevel;
        }

        private static bool IsEnough(int cost)
        {
            var value = PlayerPrefs.GetInt(CostKey);
            return cost <= value;
        }
    }
}