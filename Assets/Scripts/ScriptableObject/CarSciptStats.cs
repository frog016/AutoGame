using UnityEngine;

[CreateAssetMenu(fileName = "CarData_01", menuName = "Car_Stats", order = 1)]
public class CarSciptStats : ScriptableObject
{
    #region Specs
    public float speed;
    
    public float initalSpeed;
    
    public float maxSpeed;
    
    public float accelerationSpeed;
    
    public float decelerationSpeed;

    public float maxFuelTank;

    public float fuelTank;
    
    public float carHp;

    public float fuelConsumption;

    public float _maxSpeedDuration;

    #endregion

    public float FuelTank{get;set;}

    public float MaxFuelTank{get;set;}
 
}
