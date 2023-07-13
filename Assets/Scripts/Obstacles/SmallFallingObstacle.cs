using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    public class SmallFallingObstacle : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("car"))
            {
                //other.gameObject.GetComponent<Driving.Car>().Health.ApplyDamage(10);
                other.gameObject.GetComponent<CarScript>().ChangeHealth(-0.2f);
            }
        }
    } 
}

