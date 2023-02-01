using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManeMenuScript : MonoBehaviour
{
    public void ClickExit()
    {
        Application.Quit();
    }

    public void ClickStart()
    {
        SceneManager.LoadScene(6);
    }

    public void ClickFunctions()
    {
        SceneManager.LoadScene(2);
    }

    public void ClickProgress()
    {
        SceneManager.LoadScene(3);
    }

    public void ClickGarage()
    {
        SceneManager.LoadScene(4);
    }

    public void ClickSettings()
    {
        SceneManager.LoadScene(5);
    }
}

