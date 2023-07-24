using UnityEngine;
using UnityEngine.UI;

namespace Old
{
    public class GarageProgress : MonoBehaviour
    {
        public Text textToEdit;
        public Text textToEditOne;
        private int totalClick;
        private int maxClick = 5;

        public void ChangeText()
        {
            if (totalClick < maxClick)
            {
                totalClick += 1;
                textToEdit.text = totalClick.ToString();
                textToEditOne.text = totalClick.ToString();
            }
        }
    }
}
