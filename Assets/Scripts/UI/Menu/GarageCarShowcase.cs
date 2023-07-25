using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarageCarShowcase : MonoBehaviour
{
    [SerializeField] private Image carSprite;
    [SerializeField] private Sprite carSedan;
    [SerializeField] private Sprite carJeep;
    [SerializeField] private Sprite carOffroad;
    
    void Start()
    {
        switch (ChoiceManager.CurrentCar)
        {
            case Car.Sedan:
                carSprite.sprite = carSedan;
                break;
            case Car.Jeep:
                carSprite.sprite = carJeep;
                break;
            case Car.Offroad:
                carSprite.sprite = carOffroad;
                break;
        }
    }
}
