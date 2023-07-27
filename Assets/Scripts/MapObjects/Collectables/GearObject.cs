using UnityEngine;

namespace MapObjects.Collectables
{
    public class GearObject : MapObject
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("car"))
            {
                PlayerPrefs.SetInt("GearsAmount", PlayerPrefs.GetInt("GearsAmount") + 1);
                //Debug.Log("Got a GEAR");
                Destroy(gameObject);
            }
        }
    }
}
