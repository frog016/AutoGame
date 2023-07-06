using UnityEngine;

namespace Driving
{
    public class Car : MonoBehaviour
    {
        [Tooltip("Meter per second"), SerializeField] private float _acceleration;
        [Tooltip("Meter per second"), SerializeField] private float _maxSpeed;
        [Tooltip("Consumption per second"), SerializeField] private float _fuelConsumption;
        [SerializeField] private float _fuelCapacity;

        [SerializeField] private float _wheelRadius;
        [SerializeField] private WheelJoint2D _mainWheelJoint;

        private FuelTank _fuelTank;
        private Wheel _mainWheel;

        private void Start()
        {
            _mainWheel = new Wheel(_maxSpeed, _acceleration, _wheelRadius, _mainWheelJoint);
            _fuelTank = new FuelTank(_fuelCapacity);
        }

        private void FixedUpdate()
        {
            HandleMoveDirection();
        }

        private void HandleMoveDirection()
        {
            var direction = Mathf.RoundToInt(Input.GetAxis("Horizontal"));
            var consumedFuel = _fuelConsumption * Time.fixedDeltaTime;

            switch (direction)
            {
                case -1 when _mainWheel.Velocity.x > 0:
                case 1 when _mainWheel.Velocity.x < 0:
                    _mainWheel.Brake();
                    break;
                case -1 or 1 when _fuelTank.IsFuelEnough(consumedFuel):
                    _mainWheel.Accelerate(direction);
                    _fuelTank.Consume(consumedFuel);
                    break;
            }
        }
    }
}