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
    }

    public void OnButtonResume()
    {
        pausePanel.SetActive(false);
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
