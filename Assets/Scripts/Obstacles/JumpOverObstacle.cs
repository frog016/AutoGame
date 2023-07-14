using UnityEngine;

namespace Obstacles
{
    public class JumpOverObstacle : MonoBehaviour
    {
        [SerializeField] private int damage;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("car"))
            {
                other.GetComponent<Driving.Car>().Health.ApplyDamage(damage);
                Debug.Log("Lost health to HATCH");
                Destroy(gameObject);
            }
        }
    }
}
