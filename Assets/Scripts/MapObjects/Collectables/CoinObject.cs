using UnityEngine;

namespace MapObjects.Collectables
{
    public class CoinObject : MapObject
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("car"))
            {
                PlayerPrefs.SetInt("CoinsAmount", PlayerPrefs.GetInt("CoinsAmount") + 1);
                Debug.Log("Got a COIN");
                Destroy(gameObject);
            }
        }
    }
}
