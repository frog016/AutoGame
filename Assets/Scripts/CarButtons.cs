using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarButtons : MonoBehaviour
{
    GameObject player;
    float clicksCounter=0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExternalEngineTurnOn(bool forward)
    {
        player.GetComponent<carEngine>().EngineTurnOn(forward);
    }
     public void ExternalBrakesTurnOn()
    {
        player.GetComponent<carEngine>().BrakesTurnOn();
    }
    public void ExternalEngineNoAbuse()
    {
       clicksCounter++;
       if(clicksCounter>=10)
       {
            /*   player.GetComponent<carEngine>().ConsumeFaster();
                clicksCounter=0; */
          player.GetComponent<carEngine>().ConsumeFuel();
          clicksCounter=0;
       }
       
    }
}
