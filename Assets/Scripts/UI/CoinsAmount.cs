using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CoinsAmount : MonoBehaviour
    {
        [SerializeField] private Text coinsText;

        private void Update()
        {
            coinsText.text = PlayerPrefs.GetInt("CoinsAmount").ToString();
        }
    }
}
