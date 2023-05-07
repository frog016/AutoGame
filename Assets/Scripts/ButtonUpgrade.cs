using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUpgrade : MonoBehaviour
{
    public string upgrade;

    public void addUpgrade() {
        if (!PlayerPrefs.HasKey(upgrade)) {
            PlayerPrefs.SetFloat(upgrade, 1f);
        } 
        float currentUpgrade = PlayerPrefs.GetFloat(upgrade);
        switch (upgrade) {
            case "maxSpeedUpgrade":
                PlayerPrefs.SetFloat(upgrade, currentUpgrade + 0.1f);
                break;
            case "accelerationUpgrade":
                PlayerPrefs.SetFloat(upgrade, currentUpgrade + 0.04f);
                break;
            case "tireUpgrade":
                PlayerPrefs.SetFloat(upgrade, currentUpgrade * 1.2f);
                break;
            case "chassisUpgrade":
                PlayerPrefs.SetFloat(upgrade, currentUpgrade - 0.04f);
                break;  
            case "fuelUpgrade":
                PlayerPrefs.SetFloat(upgrade, currentUpgrade - 0.07f);
                break;          
        }
    }
}
