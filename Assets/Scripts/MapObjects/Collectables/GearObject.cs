using System.Collections;
using System.Collections.Generic;
using MapObjects;
using UnityEngine;

public class GearObject : MapObject
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("car"))
        {
            PlayerPrefs.SetInt("GearsAmount", PlayerPrefs.GetInt("GearsAmount") + 1);
            Debug.Log("Got a GEAR");
            Destroy(gameObject);
        }
    }
}
