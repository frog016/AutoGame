using UnityEngine;

namespace MapObjects.Obstacles
{
    public class PolicePostObstacle : MapObject
    {
        [Header("Police Post Obstacle")]
        [SerializeField] private float speedLimit;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("car"))
            {
                var car = other.GetComponent<Driving.Car>();
                var carSpeed = car.MainWheel.VelocityInKmph.magnitude;

                if (carSpeed > speedLimit)
                {
                    PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - (1 + (int)carSpeed - 20));
                    //Debug.Log("Lost money to POLICEPOST");
                }
            }
        }
    } 
}


