using UnityEngine;
using UnityEngine.UI;

namespace Old
{
    public class CarSelectionAndUpgrade : MonoBehaviour
    {
        public string product;

        public Image[] emptyIcons;
        public Sprite fillIcons;
        public Sprite emptyIcon;
        public int limit;

        public GameObject[] cars, bundlesButtons;
        public int selectedCar = 0;
        public int selectedCarUpg = 0;

        void Start()
        {
            IconUpd();
        }
        public void Upgraid()
        {
            int count = PlayerPrefs.GetInt(product);
            if (count < limit)
            {
                count++;
                PlayerPrefs.SetInt(product, count);
                emptyIcons[count - 1].overrideSprite = fillIcons;
            }
        }

        void IconUpd()
        {
            int count = PlayerPrefs.GetInt(product);
            for(int i = 0; i < count; i++)
            {
                emptyIcons[i].overrideSprite = fillIcons;
            }
        }



        public void NextCar()
        {
            bundlesButtons[selectedCarUpg].SetActive(false);
            selectedCarUpg = (selectedCarUpg + 1) % bundlesButtons.Length;
            bundlesButtons[selectedCarUpg].SetActive(true);

            cars[selectedCar].SetActive(false);
            selectedCar = (selectedCar + 1) % cars.Length;
            cars[selectedCar].SetActive(true);
        }

        public void PreviousCar()
        {
            bundlesButtons[selectedCarUpg].SetActive(false);
            selectedCarUpg--;
            if (selectedCarUpg < 0)
            {
                selectedCarUpg += bundlesButtons.Length;
            }
            bundlesButtons[selectedCarUpg].SetActive(true);



            cars[selectedCar].SetActive(false);
            selectedCar--;
            if (selectedCar < 0)
            {
                selectedCar += cars.Length;
            }
            cars[selectedCar].SetActive(true);
        }

    }
}

/*
 * void Start()
    {
        IconUpd();
    }

    public void Upgraid()
    {
        int count = PlayerPrefs.GetInt(product);
        if (count < limit)
        {
            count++;
            PlayerPrefs.SetInt(product, count);
            emptyIcons[count - 1].overrideSprite = fillIcons;
        }
    }

    void IconUpd()
    {
        int count = PlayerPrefs.GetInt(product);
        for(int i = 0; i < count; i++)
        {
            emptyIcons[i].overrideSprite = fillIcons;
        }
    } */