using UnityEngine;

namespace Driving
{
    [CreateAssetMenu(menuName = "Data/Car Config", fileName = "{Car Name} Config")]
    public class CarStatsConfig : ScriptableObject
    {
        [field: SerializeField] public float Acceleration { get; set; }
        [field: SerializeField] public float MaxSpeed { get; set; }
        [field: SerializeField] public float FuelCapacity { get; set; }
        [field: SerializeField] public float FuelConsumption { get; set; }
        [field: SerializeField] public int MaxHealth { get; set; }
    }
}