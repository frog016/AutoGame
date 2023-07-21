using UnityEngine;

namespace Old
{
    public class PanelOpen : MonoBehaviour
    {
        public GameObject Panel;
        public GameObject PanelOne;
        public GameObject PanelTwo;
        public GameObject PanelThree;

        public void OpenPanel()
        {
            if (Panel != null)
            {
                bool isActive = Panel.activeSelf;
                Panel.SetActive(!isActive);
            }

            if(PanelOne != null)
            {
                bool isActive = PanelOne.activeSelf;
                PanelOne.SetActive(!isActive);
            }

            if (PanelTwo != null)
            {
                bool isActive = PanelTwo.activeSelf;
                PanelTwo.SetActive(!isActive);
            }

            if (PanelThree != null)
            {
                bool isActive = PanelThree.activeSelf;
                PanelThree.SetActive(!isActive);
            }
        }
    }
}