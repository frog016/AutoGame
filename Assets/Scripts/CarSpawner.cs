using System.Collections;
using System.Collections.Generic;
using Driving;
using InputSystem;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject carSedan;
    [SerializeField] private GameObject carJeep;
    [SerializeField] private GameObject carOffroad;
    
    // Start is called before the first frame update
    void Awake()
    {
        switch (ChoiceManager.CurrentCar)
        {
            case Car.Sedan:
                var sedan = Instantiate(carSedan, transform.position, Quaternion.identity, transform);
                break;
            case Car.Jeep:
                var jeep = Instantiate(carJeep, transform.position, Quaternion.identity, transform);
                break;
            case Car.Offroad:
                var offroad = Instantiate(carOffroad, transform.position, Quaternion.identity, transform);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
