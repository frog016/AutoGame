using UnityEngine;

namespace Old
{
    public class ButtonUpgrade : MonoBehaviour
    {
        public string upgrade;

        public void addUpgrade() {
            if (!PlayerPrefs.HasKey(upgrade)) {
                PlayerPrefs.SetInt(upgrade, 1);
            } 
            int currentUpgrade = PlayerPrefs.GetInt(upgrade);
            if (currentUpgrade == 5) {
                return;
            }
            switch (upgrade) {
                case "maxSpeedUpgrade":
                    PlayerPrefs.SetInt(upgrade, currentUpgrade + 1);
                    break;
                case "accelerationUpgrade":
                    PlayerPrefs.SetInt(upgrade, currentUpgrade + 1);
                    break;
                case "tireUpgrade":
                    PlayerPrefs.SetInt(upgrade, currentUpgrade + 1);
                    break;
                case "chassisUpgrade":
                    PlayerPrefs.SetInt(upgrade, currentUpgrade + 1);
                    break;  
                case "fuelUpgrade":
                    PlayerPrefs.SetInt(upgrade, currentUpgrade + 1);
                    break;          
            }
        }
    }
}
