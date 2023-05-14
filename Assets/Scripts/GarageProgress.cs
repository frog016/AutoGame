using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarageProgress : MonoBehaviour
{
    public Text textToEdit;
    public Text textToEditOne;
    private int totalClick;

    void Start()
    {
        textToEdit = GetComponentInChildren<Text>();
        textToEditOne = GetComponentInChildren<Text>();
    }

    public void ChangeText()
    {
        if (totalClick < 14)
        {
            totalClick += 1;
            textToEdit.text = totalClick.ToString();
            textToEditOne.text = totalClick.ToString();
        }
    }
}
