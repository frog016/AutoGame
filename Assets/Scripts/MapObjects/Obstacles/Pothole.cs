using UnityEngine;

namespace Obstacles
{
    public class Pothole : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("car"))
            {
                var car = other.GetComponent<Driving.Car>();
                var carSpeed = car.MainWheel.Velocity.magnitude * 3.6;
                
                if (carSpeed > 30)
                    car.Health.ApplyDamage(20);
            }
        }
    }
}
