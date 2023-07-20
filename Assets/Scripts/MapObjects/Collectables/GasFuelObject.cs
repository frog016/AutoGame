using UnityEngine;
using UnityEngine.Serialization;

namespace MapObjects
{
    public class GasFuelObject : MapObject
    {
        [SerializeField] private float refuelFractionOfMax;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("car"))
            {
                var carFuelTank = other.GetComponent<Driving.Car>().FuelTank;
                carFuelTank.Refuel(carFuelTank.FuelCapacity / refuelFractionOfMax);
                Debug.Log("Got some FUEL");
                Destroy(gameObject);
            }
        }
    }
}
