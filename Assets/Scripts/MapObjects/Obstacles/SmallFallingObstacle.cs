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
                other.gameObject.GetComponent<Driving.Car>().Health.ApplyDamage(damage);
                //Debug.Log("Lost health to BRICK");
                Destroy(gameObject);
            }
        }
    } 
}

