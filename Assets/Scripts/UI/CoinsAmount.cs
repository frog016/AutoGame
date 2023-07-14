using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsAmount : MonoBehaviour
{
    [SerializeField] private Text coinsText;

    private void Update()
    {
        coinsText.text = PlayerPrefs.GetInt("coins").ToString();
    }
}
