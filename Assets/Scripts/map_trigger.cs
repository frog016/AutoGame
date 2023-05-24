using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class map_trigger : MonoBehaviour
{
    public string trigger;
    public Text coinCount;
    private CarScript car;

    void Awake() {
        coinCount = GameObject.FindGameObjectWithTag("coins").GetComponent<Text>();
        coinCount.text = PlayerPrefs.GetInt("coins").ToString();
        car = FindObjectOfType<CarScript>();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "s_car") {
            switch (trigger) {
                case "coin":
                int coins = PlayerPrefs.GetInt("coins");
                PlayerPrefs.SetInt("coins", coins + 1);
                Destroy(gameObject);
                coinCount.text = (coins + 1).ToString();
                break;
                case "fuel":
                car.collectFuel();
                Destroy(gameObject);
                break;
                case "police":
                Debug.Log("police");
                car.policeStop();
                break;
            }
        }
    }
}
