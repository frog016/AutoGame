using UnityEngine;

namespace MapObjects.Obstacles
{
    public class JumpOverObstacle : MapObject
    {
        [Header("Jump Over Obstacle")]
        [SerializeField] private int damage;
        [SerializeField] private float speedLimit;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("car"))
            {
                var car = other.gameObject.GetComponent<Driving.Car>();
				if (car == null)
					car = other.gameObject.transform.parent.GetComponent<Driving.Car>();
                var carSpeed = car.MainWheel.VelocityInKmph.magnitude;

                if (carSpeed > speedLimit)
                {
                   car.Health.ApplyDamage(damage);
                }
                //Debug.Log("Lost health to HATCH");
                //Destroy(gameObject);
            }
        }
    }
}
