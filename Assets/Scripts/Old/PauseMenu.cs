using UnityEngine;
using UnityEngine.SceneManagement;

namespace Old
{
    public class PauseMenu : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        public void RestartLevel() //Restarts the level
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
            Time.timeScale = 1f;
        }
    }
}