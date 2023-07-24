using UnityEngine;

namespace Old
{
    public class settingsInPlay : MonoBehaviour
    {
        public GameObject Setting;
        public void ClickSettings()
        {
            Setting.SetActive(true);
        }
    }
}
