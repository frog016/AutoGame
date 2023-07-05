using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WheelSpin : MonoBehaviour
{
    [System.Serializable]
    struct rewards
    {
        [SerializeField]
        string red;
        [SerializeField]
        string purple;
        [SerializeField]
        string blue;
        [SerializeField]
        string lightBlue;
        [SerializeField]
        string green;
        [SerializeField]
        string yellow;

        public string GetInList(int num)
        {
            switch(num)
            {
                case 0 :
                 return red;
                case 1 :
                    return purple;
                case 2 :
                    return blue;
                case 3 : 
                    return lightBlue;
                case 4:
                    return green;
                default:
                    return yellow;
            }
        }

    }
    public float genSpeed;
    public float subSpeed;
    private bool isSpinning = false;

    [SerializeField]
    Button spinButton;

    [SerializeField]
    GameObject childText;

    [SerializeField]
    GameObject pinTip;

    [SerializeField]
    LayerMask rewardsLayer;

    bool getReward=false;
    bool finishedReward = false;

    [SerializeField]
    rewards rewardList;
    

    [SerializeField, Range(2.0f, 4.0f)] 
    float genSpeedMin;
    [SerializeField, Range(5.0f, 10f)] 
    float genSpeedMax;


    [SerializeField, Range(0.0009f, 0.002f)] 
    float subSpeedMin;
    [SerializeField, Range(0.003f, 0.007f)] 
    float subSpeedMax;

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
          Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(pinTip.transform.position, 10f);
    }
    // Start is called before the first frame update
    void Start()
    {
       for(int i = 0 ; i < transform.childCount ; i++)
        {
            foreach(Transform child in transform.GetChild(i))
            {
                var spawned = Instantiate (childText, new Vector3(child.transform.position.x,child.transform.position.y+6f, 0) , Quaternion.identity);
                spawned.transform.SetParent(child);
                spawned.GetComponent<TextMeshProUGUI>().text = rewardList.GetInList(i);
            
            }
        }
        
       
    }

    // Update is called once per frame
    void Update()
    {

        if(isSpinning)
        {
            transform.Rotate(0,0,-genSpeed,Space.World);
            genSpeed-=subSpeed;
        }

        if(genSpeed <= 0)
        {
            genSpeed=0;
            isSpinning=false;
            spinButton.interactable=true;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(pinTip.transform.position, 10f, rewardsLayer);
            if(colliders[0] && getReward && !finishedReward)
            {
                //Debug.Log(colliders[0].gameObject.name);
                //Debug.Log(pinTip.transform.position.x - colliders[0].transform.position.x);
                float tempDist = float.MaxValue;
                int winnerDist = 0;
                for(int i = 0 ; i <colliders.Length;i++)
                {
                    if( Mathf.Abs(pinTip.transform.position.x-colliders[i].transform.position.x)<tempDist )
                    {
                        tempDist= Mathf.Abs(pinTip.transform.position.x-colliders[i].transform.position.x);
                        winnerDist=i;
                    }
                   
                }
    
                if(pinTip.transform.position.x - colliders[winnerDist].transform.position.x>20f && !isSpinning)
                {
                    transform.Rotate(0,0,-0.5f,Space.World);
                }
                else
                {
                    finishedReward = true;
                    getReward = false;
                    Debug.Log(colliders[winnerDist].gameObject.name);
                    string rewardText = colliders[winnerDist].GetComponentInChildren<TextMeshProUGUI>().text;
                    Debug.Log(rewardText);
                }
            
            }

        }
        

    }

    public void SpinMyWheel()
    {
        genSpeed = Random.Range(2.0f,5.0f);
        subSpeed = Random.Range(subSpeedMin,subSpeedMax);
        isSpinning=true;
        spinButton.interactable=false;
        getReward=true;
        finishedReward = false;
    }
}
