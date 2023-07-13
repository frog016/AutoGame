using UnityEngine;

namespace Obstacles
{
    public class BigFallingObstacle : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("car"))
            {
                //other.gameObject.GetComponent<Driving.Car>().Health.ApplyDamage(50);
                other.gameObject.GetComponent<CarScript>().ChangeHealth(-0.6f);
            }
        }
    }
}
