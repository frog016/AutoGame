using UnityEngine;

namespace MapObjects.Collectables
{
    public class CallTowtruckObject : MapObject
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("car"))
            {
                // TODO: heal player
                //other.GetComponent<Driving.Car>().Health.
                Debug.Log("Called a TOWTRUCK");
                Destroy(gameObject);
            }
        }
    }
}
