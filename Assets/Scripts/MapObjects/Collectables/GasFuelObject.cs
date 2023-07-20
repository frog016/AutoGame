using UnityEngine;

namespace MapObjects
{
    public class GasFuelObject : MapObject
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("car"))
            {
                other.GetComponent<Driving.Car>().FuelTank.Refuel(10.0f);
                Debug.Log("Got some FUEL");
                Destroy(gameObject);
            }
        }
    }
}
