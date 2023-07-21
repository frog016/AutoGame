using UnityEngine;

namespace Old
{
    public class StartGameAfterCutscene : MonoBehaviour
    {
        public void StartGame()
        {
            CutsceneManager.Instance.StartGame();
        }
    }
}
