using Health;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Driving
{
    public class Car : MonoBehaviour
    {
        [Tooltip("Meter per second"), SerializeField] private float _passiveDeceleration;
        [SerializeField] private float _wheelRadius;
        [SerializeField] private WheelJoint2D _mainWheelJoint;
        [SerializeField] private WheelJoint2D _secondWheelJoint;

        public float FuelConsumption { get; private set; }
        public FuelTank FuelTank { get; private set; }
        public Wheel MainWheel { get; private set; }
        public Wheel SecondWheel { get; private set; }
        public IDamageable Health { get; private set; }

        public void Initialize(CarStatsConfig config)
        {
            FuelConsumption = config.FuelConsumption;
            MainWheel = CreateWheel(config.MaxSpeed, config.Acceleration, _mainWheelJoint);
            SecondWheel = CreateWheel(config.MaxSpeed, config.Acceleration, _secondWheelJoint);
            FuelTank = new FuelTank(config.FuelCapacity);
            Health = new DamageableObject(config.MaxHealth);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position += new Vector3(0, 3);
                transform.rotation = Quaternion.identity;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        private Wheel CreateWheel(float maxSpeed, float acceleration, WheelJoint2D wheelJoint)
        {
            return new Wheel(maxSpeed, acceleration, _passiveDeceleration, _wheelRadius, wheelJoint);
        }
    }
}