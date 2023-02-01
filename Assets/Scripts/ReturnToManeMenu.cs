using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToManeMenu : MonoBehaviour
{    public void ClickExit()
    {
        SceneManager.LoadScene(0);
    }
}
