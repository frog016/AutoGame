using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GearsAmount : MonoBehaviour
{
    [SerializeField] private Text gearsText;
    [SerializeField] private int healFractionOfMax;
    
    public void OnClickGear()
    {
        var currentGearAmount = PlayerPrefs.GetInt("GearsAmount");
        if (currentGearAmount == 0)
            return;
        
        PlayerPrefs.SetInt("GearsAmount", currentGearAmount - 1);
        var carHealth = FindObjectOfType<Driving.Car>().Health;
        carHealth.ApplyHeal(carHealth.MaxHealth / healFractionOfMax);
    }
    
    void Update()
    {
        gearsText.text = PlayerPrefs.GetInt("GearsAmount").ToString();
    }
}
