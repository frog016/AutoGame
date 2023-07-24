using UnityEngine;

namespace Driving
{
    public class CarInitializer : MonoBehaviour
    {
        [SerializeField] private Car _car;
        [SerializeField] private CarStatsConfig _config;

        private void Awake()
        {
            _car.Initialize(_config);
        }
    }
}