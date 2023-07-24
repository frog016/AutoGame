using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsWindow;
    
    public void OnButtonSettings()
    {
        settingsWindow.SetActive(true);
    }
    
    public void OnButtonCloseSettings()
    {
        settingsWindow.SetActive(false);
    }

    public void OnButtonExit()
    {
        Application.Quit();
    }

    public void OnButtonPlay()
    {
        SceneManager.LoadScene("LocationMenu");
    }

    public void OnButtonAchievements()
    {
        SceneManager.LoadScene("ProgressScene");
    }
    
    public void OnButtonShop()
    {
        SceneManager.LoadScene("ShopScene");
    }
}
