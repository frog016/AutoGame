using UnityEngine;
using UnityEngine.SceneManagement;

namespace Old
{
    public class ReturnToManeMenu : MonoBehaviour
    {    public void ClickExit()
        {
            SceneManager.LoadScene(0);
        }
    }
}
