using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    
    public string objectName;
    public int price, access;
    public GameObject block, active, activeButton;
    public Text objectPrice, coinCount;
    
    void Awake()
    {
        PlayerPrefs.SetInt("coins",0);
        AccessUpdate();
    }
    void AccessUpdate()
    {
        access = PlayerPrefs.GetInt(objectName + "Access");
        objectPrice.text = price.ToString();
        coinCount.text = PlayerPrefs.GetInt("coins").ToString();

        block.SetActive(true);
        active.SetActive(false);

        if (access == 1)
        {
            block.SetActive(false);
            active.SetActive(true);
            objectPrice.gameObject.SetActive(false);
            activeButton.gameObject.SetActive(false);


        }
    }

    public void Buy()
    {
        int coins = PlayerPrefs.GetInt("coins");

        if (access == 0)
        {
            if (coins >= price)
            {
                PlayerPrefs.SetInt(objectName + "Access", 1);
                PlayerPrefs.SetInt("coins", coins - price);
                AccessUpdate();
            }
        }
    }
}
