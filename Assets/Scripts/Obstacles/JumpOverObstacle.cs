using UnityEngine;

namespace Obstacles
{
    public class JumpOverObstacle : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("car"))
            {
                other.GetComponent<Driving.Car>().Health.ApplyDamage(30);
            }
        }
    }
}
