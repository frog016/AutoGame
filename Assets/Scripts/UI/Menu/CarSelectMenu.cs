using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Menu
{
    public class CarSelectMenu : MonoBehaviour
    {
        public void OnButtonBack()
        {
            SceneManager.LoadScene("LocationMenu");
        }

        public void OnButtonStart()
        {
            SceneManager.LoadScene("LevelCity");
        }

        public void OnButtonGarage()
        {
            SceneManager.LoadScene("GarageMenu");
        }
    }
}
