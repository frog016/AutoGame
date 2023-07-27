using System;
using System.Collections;
using System.Collections.Generic;
using Cutsceens;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private CutsceenLoadArguments cutsceenLoader;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("car"))
        {
            PlayerPrefs.SetInt("CoinsAmount", PlayerPrefs.GetInt("CoinsAmount") + PlayerPrefs.GetInt("GearsAmount"));
            PlayerPrefs.SetInt("GearsAmount", 0);
            
            cutsceenLoader.LoadCutsceenArgs(ChoiceManager.CurrentCutscene, CutsceenLoadArguments.CutsceenState.End);
            SceneManager.LoadScene("CutscenePlayer");
        }
    }
}
