using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    public class HighSpeedPassObstacle : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private float speedLimit;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("car"))
            {
                var car = other.GetComponent<Driving.Car>();
                var carSpeed = car.MainWheel.VelocityInKmph.magnitude;
                
                if (carSpeed > speedLimit)
                {
                    car.Health.ApplyDamage(damage);
                    Debug.Log("Lost health to GRAVEL");
                }
            }
        }
    }  
}

