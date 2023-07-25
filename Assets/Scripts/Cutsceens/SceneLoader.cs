using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cutsceens
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadGamePlayLevel()
        {
            SceneManager.LoadScene("LevelCity");
        }

        public void LoadMenuLevel()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}