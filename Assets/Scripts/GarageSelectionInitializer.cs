using System;
using System.Collections.Generic;
using System.Linq;
using Driving;
using UI.Presenter;
using UI.View;
using UnityEngine;
using Upgrade;

public class GarageSelectionInitializer : MonoBehaviour
{
    [SerializeField] private UpgradeSystemPresenter _presenter;
    [SerializeField] private UpgradeButton[] _buttons;
    [SerializeField] private CarStatsPair[] _carStats;
    [SerializeField] private CarParametersPair[] _carsParameters;

    private void Awake()
    {
        var carStats = GetCurrentCar();
        _presenter.Initialize(carStats);

        var parameters = GetParametersForCar();
        var buttonParameterPair = _buttons.Zip(parameters, Tuple.Create);
        foreach (var (button, parameter) in buttonParameterPair)
            button.Initialize(parameter);
    }

    private CarStatsConfig GetCurrentCar()
    {
        return _carStats.First(pair => pair.CarType == ChoiceManager.CurrentCar).StatsConfig;
    }

    private IEnumerable<UpgradableParameterConfig> GetParametersForCar()
    {
        return _carsParameters.First(pair => pair.CarType == ChoiceManager.CurrentCar).Config;
    }

    [Serializable]
    public class CarStatsPair
    {
        [field: SerializeField] public Car CarType { get; private set; }
        [field: SerializeField] public CarStatsConfig StatsConfig { get; private set; }
    }

    [Serializable]
    public class CarParametersPair
    {
        [field: SerializeField] public Car CarType { get; private set; }
        [field: SerializeField] public UpgradableParameterConfig[] Config { get; private set; }
    }
}