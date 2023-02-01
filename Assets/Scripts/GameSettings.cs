using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameSettings : MonoBehaviour
{
    public Image infGameImage;
    public Image trialGameImage;
    public Sprite on;
    public Sprite off;
    bool infGame = true;
    bool trialGame = false;

    public void InfGame()
    {
        bool infGame = true;
        infGameImage.overrideSprite = on;
        bool trialGame = false;
        trialGameImage.overrideSprite = off;
    }

    public void TrialGame()
    {
        bool trialGame = true;
        trialGameImage.overrideSprite = on;
        bool infGame = false;
        infGameImage.overrideSprite = off;
    }
}
