using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDeath : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(LayerMask.LayerToName(col.gameObject.layer) == "Ground")
        {
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            Debug.Log("death");
            GameObject.FindWithTag("DeathMenu").transform.GetChild (0).gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
