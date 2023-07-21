using UnityEngine;
using UnityEngine.SceneManagement;

namespace Old
{
    public class MainMenu : MonoBehaviour
    {
        public void LoadScene()
        {
            PlayerPrefs.SetInt("num", 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        void Update() 
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }    
        }
    }
}
