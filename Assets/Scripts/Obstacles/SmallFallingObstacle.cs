using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    public class SmallFallingObstacle : MonoBehaviour
    {
        [SerializeField] private int damage;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("car"))
            {
                other.gameObject.GetComponent<Driving.Car>().Health.ApplyDamage(damage);
                Debug.Log("Lost health to BRICK");
                Destroy(gameObject);
            }
        }
    } 
}

