using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Old
{
    public class AnimationCTRL : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject background;
        [SerializeField] private GameObject backgroundUI;
        [SerializeField] private GameObject backgroundUI2;
        [SerializeField] private GameObject spriteRenderer;
        [SerializeField] private Sprite[] spritesCar = new Sprite[3];
        private bool isEndScene = false;
    
        void Start() 
        {
            background.SetActive(true);
            backgroundUI2.SetActive(true);
            animator.GetComponent<Animator>();
            spriteRenderer = GameObject.Find("AnimationCar");
            isEndScene = false;

            if (PlayerPrefs.GetInt("num") == 1)
            {   
                Debug.Log("Финальная сцена!");
                PlayScreenEnd();
                PlayerPrefs.SetInt("num", 0);
            }
        }

        public void PlayScreenStart(string name)
        {
            var rndElement = Random.Range(0, 4);
            Debug.Log(rndElement);

            if(rndElement == 0)
            {
                name = "Friend";
            }
            else if(rndElement == 1)
            {
                name = "Cat";
            }
            else if(rndElement == 2)
            {
                name = "Shop";
            }
            else
            {
                name = "Ded";
            }

            switch(name)
            {
                case "Friend":
                    PlayerPrefs.SetString("screenName", "Friend_End");

                    animator.SetTrigger("Friend");
                    Invoke("StartScene", 12);
                    break;

                case "Cat":
                    PlayerPrefs.SetString("screenName", "Cat_End");

                    animator.SetTrigger("Cat");
                    Invoke("StartScene", 13);
                    break;

                case "Shop":
                    PlayerPrefs.SetString("screenName", "Shop_End");

                    animator.SetTrigger("Shop");
                    Invoke("StartScene", 10);
                    break;

                case "Ded":
                    PlayerPrefs.SetString("screenName", "Ded_End");

                    animator.SetTrigger("Ded");
                    Invoke("StartScene", 10.5f);
                    break;
            }
        }
        public void PlayScreenEnd()
        {
            isEndScene = true;
            spriteRenderer.GetComponent<Image>().sprite = spritesCar[PlayerPrefs.GetInt("car")];
            background.SetActive(false);
            backgroundUI.SetActive(false);
            backgroundUI2.SetActive(false);
            switch (PlayerPrefs.GetString("screenName"))
            {
                case "Friend_End":
                    animator.SetTrigger("Friend_End");
                    Invoke("Start", 5);
                    break;
                case "Cat_End":
                    animator.SetTrigger("Cat_End");
                    Invoke("Start", 5);
                    break;
                case "Shop_End":
                    animator.SetTrigger("Shop_End");
                    Invoke("Start", 10.5f);
                    break;
                case "Ded_End":
                    animator.SetTrigger("Ded_End");
                    Invoke("Start", 9);
                    break;
            }     
        }

        public void ChooseCar(int car)
        {
            PlayerPrefs.SetInt("car", car);
            spriteRenderer.GetComponent<Image>().sprite = spritesCar[car];
        }

        public void StartScene()
        {
            if(isEndScene == true)
            {
                Start();
            }
            else
            {
                SceneManager.LoadScene(7);
            }
        }
    }
}