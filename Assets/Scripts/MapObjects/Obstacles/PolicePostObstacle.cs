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
                var car = other.gameObject.GetComponent<Driving.Car>();
				if (car == null)
					car = other.gameObject.transform.parent.GetComponent<Driving.Car>();
                var carSpeed = car.MainWheel.VelocityInKmph.magnitude;
				var moneyReduction = 1 + (int)carSpeed - 20;
				
                if (carSpeed > speedLimit)
                {
					if (PlayerPrefs.GetInt("CoinsAmount") - moneyReduction <= 0)
					{
						PlayerPrefs.SetInt("CoinsAmount", 0);
						return;
					}
						
					
                    PlayerPrefs.SetInt("CoinsAmount", PlayerPrefs.GetInt("CoindAmount") - moneyReduction);
                    //Debug.Log("Lost money to POLICEPOST");
                }
            }
        }
    } 
}


