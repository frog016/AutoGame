using UnityEngine;
using UnityEngine.UI;

namespace Old
{
    public class HealthBar : MonoBehaviour
    {
        public Image healthBar;
        public CarScript car;

        void Start()
        {
            healthBar = GetComponent<Image>();
            car = FindObjectOfType<CarScript>();
        }

        public void Update()
        {
            //healthBar.fillAmount = car.health / car.maxHealth;
        }
    }
}
