using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacleTrigger : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("car"))
        {
            obstacle.SetActive(true);
        }
    }
}
