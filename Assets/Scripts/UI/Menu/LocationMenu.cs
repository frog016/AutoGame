using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Menu
{
    public class LocationMenu : MonoBehaviour
    {
        [SerializeField] private GameObject withGoalButton;
        [SerializeField] private GameObject infiniteButton;
        
        public void OnButtonBack()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void OnButtonCarSelect()
        {
            SceneManager.LoadScene("CarSelectMenu");
        }

        public void OnButtonWithGoal()
        {
            ChoiceManager.CurrentGamemode = Gamemode.WithGoal;
            withGoalButton.transform.GetChild(0).gameObject.SetActive(true);
            withGoalButton.transform.GetChild(1).gameObject.SetActive(false);
            infiniteButton.transform.GetChild(0).gameObject.SetActive(false);
            infiniteButton.transform.GetChild(1).gameObject.SetActive(true);
        }
        
        public void OnButtonInfinite()
        {
            ChoiceManager.CurrentGamemode = Gamemode.Infinite;
            withGoalButton.transform.GetChild(0).gameObject.SetActive(false);
            withGoalButton.transform.GetChild(1).gameObject.SetActive(true);
            infiniteButton.transform.GetChild(0).gameObject.SetActive(true);
            infiniteButton.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
