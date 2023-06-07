using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameAfterCutscene : MonoBehaviour
{
    public void StartGame()
    {
        CutsceneManager.Instance.StartGame();
    }
}
