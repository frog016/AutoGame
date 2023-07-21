using TMPro;
using UnityEngine;

namespace Old
{
    public class CoinCounter : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            PlayerPrefs.SetInt("levelCoins",0);
            this.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("levelCoins").ToString();
            //when lvl ends add all of them to coins
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void GetValueCoins()
        {
            //Debug.Log("COPY");
            this.GetComponent<TextMeshProUGUI>().text=PlayerPrefs.GetInt("levelCoins").ToString();
        }
    }
}
