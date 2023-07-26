using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Speedometer : MonoBehaviour
    {
        public Driving.Car car;

        public float maxSpeed = 0.0f;

        public float minSpeedArrowAngle;
        public float maxSpeedArrowAngle;

        [Header("UI")]
        public Text speedLabel;
        public RectTransform arrow;

        private float speed = 0.0f;

        public void Start()
        {
            car = FindObjectOfType<Driving.Car>();
        }
        private void Update()
        {
            speed = car.MainWheel.VelocityInKmph.magnitude;

            if (speedLabel != null)
                speedLabel.text = ((int)speed) + " km/h";
            if (arrow != null)
                arrow.localEulerAngles =
                    new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed));
        }
    }
}