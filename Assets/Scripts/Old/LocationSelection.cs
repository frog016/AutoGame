using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Old
{
    public class LocationSelection : MonoBehaviour
    {
        public int product;
        public Image[] locationImage;
        public Sprite ChosenLocation;
        public Sprite NotChosenLocation;
        public GameObject LocationSelectionMenu;
        public GameObject CarSelectionMenu;
        public GameObject BottonBackToLocationMode;
        int[] locationForPlay = new int[4];

        public void ChooseLocation()
        {
            for (int i = 0; i < 4; i++)
            {
                locationImage[i].overrideSprite = NotChosenLocation;
                locationForPlay[i] = 0;
            }
            locationImage[product].overrideSprite = ChosenLocation;
            locationForPlay[product] = 1;
        }

        public void ClichNextBotton()
        {
            LocationSelectionMenu.SetActive(false);
            CarSelectionMenu.SetActive(true);
        }

        public void ClichBottonBackToGameMode()
        {
            LocationSelectionMenu.SetActive(true);
            CarSelectionMenu.SetActive(false);
        }

        public void ClickPlay()
        {
            SceneManager.LoadScene(7);
        }
    }
}
