using System.Collections;
using System.Collections.Generic;
using Cutsceens;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CutsceenLoadArguments cutsceenLoader;
    private Driving.Car car;

    void Start()
    {
        car = FindObjectOfType<Driving.Car>();
    }

    void Update()
    {
        if (car.Health.Health <= 0)
        {
            cutsceenLoader.LoadCutsceenArgs(CutsceenName.BrokeCar, CutsceenLoadArguments.CutsceenState.End);
            SceneManager.LoadScene("CutscenePlayer");
        }
        
        if (car.FuelTank.FuelAmount <= 0)
        {
            cutsceenLoader.LoadCutsceenArgs(CutsceenName.FuelLose, CutsceenLoadArguments.CutsceenState.End);
            SceneManager.LoadScene("CutscenePlayer");
        }
    }
}
