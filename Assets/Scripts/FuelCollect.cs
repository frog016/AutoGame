using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCollect : MonoBehaviour
{
    [SerializeField]
    AudioClip myClip;

    [SerializeField]
    float capacity = 0 ;

    [SerializeField, Range(0.2f, 0.5f)] 
    float floatingTime;

    float cycleTime;

    bool goingUp = true;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
           /*  Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            Debug.Log("add fuel"); */
            if(col.GetComponent<CarSciptStats>().FuelTank < col.GetComponent<CarSciptStats>().MaxFuelTank) // add max here
            {
                col.GetComponent<CarSciptStats>().FuelTank+= capacity;
            }
         
            if(myClip)
            {
                GameObject.FindGameObjectWithTag("ExtraAudio").GetComponent<AudioSource>().PlayOneShot(myClip);
            }
            Destroy(gameObject,0.3f);         
        }
     
    }
    // Start is called before the first frame update
    void Start()
    {
        cycleTime= floatingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(cycleTime > 0 && goingUp)
        {
            cycleTime-=Time.deltaTime;
            transform.Translate(new Vector3(0,0.1f,0) * Time.deltaTime, Space.World);
        
        }
        else if (cycleTime > 0 && !goingUp)
        {
            cycleTime-=Time.deltaTime;
             transform.Translate(new Vector3(0,-0.1f,0) * Time.deltaTime, Space.World);
        }
        else
        {
            cycleTime+=floatingTime;
            goingUp = !goingUp;
        }
        
    }
}
