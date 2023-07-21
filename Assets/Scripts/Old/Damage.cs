using UnityEngine;

namespace Old
{
    public class Damage : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            CarScript controller = other.GetComponent<CarScript>();

            if (controller != null)
            {
                //controller.ChangeHealth(-10);
            }
        }
    }
}
