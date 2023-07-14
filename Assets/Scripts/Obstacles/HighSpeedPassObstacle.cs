using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    public class HighSpeedPassObstacle : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("car"))
            {
                var car = other.GetComponent<Driving.Car>();
                //var carSpeed = car.MainWheel.Velocity.magnitude * 3.6;
                var carSpeed = car.MainWheel.Velocity.magnitude;
                if (carSpeed > 30)
                {
                    car.Health.ApplyDamage(10);
                    Debug.Log("Lost health to GRAVEL");
                    Destroy(gameObject);
                }
            }
        }
    }  
}

