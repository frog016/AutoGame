using InputSystem;
using UnityEngine;

namespace Driving
{
    [RequireComponent(typeof(Car))]
    public class CarMovementController : MonoBehaviour
    {
        [SerializeField] private MoveButton[] _buttons;

        private Car _car;
        private IInputSystem _inputSystem;

        private const float VelocityEpsilon = 5e-2f;

        private void Awake()
        {
            _car = GetComponent<Car>();
            _buttons = FindObjectsOfType<MoveButton>();
            _inputSystem = new ButtonsInputSystem(_buttons[0], _buttons[1]);
        }

        private void FixedUpdate()
        {
            HandleMoveDirection();
        }

        private void HandleMoveDirection()
        {
            var direction = _inputSystem.GetMoveDirection();
            var consumedFuel = _car.FuelConsumption * Time.fixedDeltaTime;

            var velocity = _car.MainWheel.Velocity;
            switch (direction)
            {
                case -1 when velocity.x > 0:
                case 1 when velocity.x < 0:
                    _car.MainWheel.Brake();
                    _car.SecondWheel.Brake();
                    break;
                case -1 or 1 when _car.FuelTank.IsFuelEnough(consumedFuel):
                    _car.MainWheel.Accelerate(direction);
                    _car.SecondWheel.Accelerate(direction);
                    _car.FuelTank.Consume(consumedFuel);
                    break;
                case 0 when velocity.magnitude < VelocityEpsilon:
                    _car.MainWheel.StopBraking();
                    _car.SecondWheel.StopBraking();
                    break;
                case 0 when Mathf.Abs(velocity.x) > VelocityEpsilon:
                    _car.MainWheel.SlowDown();
                    _car.SecondWheel.SlowDown();
                    break;
            }
        }
    }
}