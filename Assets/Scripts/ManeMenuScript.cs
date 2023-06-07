using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManeMenuScript : MonoBehaviour
{
    public void ClickQuit()
    {
        Application.Quit();
    }

    public void ClickExit()
    {
        SceneManager.LoadScene(0);
    }

    public void ClickStart()
    {
        CutsceneManager.Instance.StartPlot(8);
    }

    public void ClickGameMode()
    {
        SceneManager.LoadScene(5);
    }

    public void ClickAuto()
    {
        SceneManager.LoadScene(7);
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

