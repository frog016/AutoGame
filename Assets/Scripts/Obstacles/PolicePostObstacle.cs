using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    public class PolicePostObstacle : MonoBehaviour
    {
        [SerializeField] private float speedLimit;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("car"))
            {
                var car = other.GetComponent<Driving.Car>();
                var carSpeed = car.MainWheel.VelocityInKmph.magnitude;

                if (carSpeed > speedLimit)
                {
                    PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - (1 + (int)carSpeed - 20));
                    Debug.Log("Lost money to POLICEPOST");
                }
            }
        }
    } 
}


