using UnityEngine;

namespace UI.Menu
{
    public class CarSelectArrow : MonoBehaviour
    {
        [SerializeField] private Car selectedCar;

        public void OnButtonArrow()
        {
            ChoiceManager.CurrentCar = selectedCar;
        }
    }
}
