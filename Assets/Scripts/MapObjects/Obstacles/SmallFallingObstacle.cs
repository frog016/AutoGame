using UnityEngine;

namespace MapObjects.Obstacles
{
    public class SmallFallingObstacle : MapObject
    {
        [Header("Small Falling Obstacle")]
        [SerializeField] private int damage;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("car"))
            {
				var car = other.gameObject.GetComponent<Driving.Car>();
				if (car == null)
					car = other.gameObject.transform.parent.GetComponent<Driving.Car>();
				car.Health.ApplyDamage(damage);
                //Debug.Log("Lost health to BRICK");
                Destroy(gameObject);
            }
        }
    } 
}

