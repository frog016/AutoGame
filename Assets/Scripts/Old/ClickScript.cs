using UnityEngine;

namespace Old
{
    public class ClickScript : MonoBehaviour
    {
        public bool clickedIs = false;
        private void OnMouseUp()
        {
            clickedIs = false;
        }
        void OnMouseDown()
        {
            clickedIs = true;
        }
    }
}
