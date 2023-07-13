using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    public class PolicePostObstacle : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("car"))
            {
                var car = other.GetComponent<Driving.Car>();
                var carSpeed = car.MainWheel.Velocity.magnitude * 3.6;
                
                if (carSpeed > 20)
                    PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - (1 + (int)carSpeed - 20));
            }
        }
    } 
}


