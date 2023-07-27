using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;
    
    public void OnButtonPause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnButtonResume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnButtonRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnButtonSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void OnButtonCloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void OnButtonExit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
