using UnityEngine;

namespace Driving
{
    [RequireComponent(typeof(Car))]
    public class CarMovementController : MonoBehaviour
    {
        private Car _car;

        private const float VelocityEpsilon = 5e-2f;

        private void Awake()
        {
            _car = GetComponent<Car>();
        }

        private void FixedUpdate()
        {
            HandleMoveDirection();
        }

        private void HandleMoveDirection()
        {
            var direction = Mathf.RoundToInt(Input.GetAxis("Horizontal"));
            var consumedFuel = _car.FuelConsumption * Time.fixedDeltaTime;

            var velocity = _car.MainWheel.Velocity;
            Debug.Log($"Direction = {direction}, Velocity = {velocity}.");
            switch (direction)
            {
                case -1 when velocity.x > 0:
                case 1 when velocity.x < 0:
                    _car.MainWheel.Brake();
                    break;
                case -1 or 1 when _car.FuelTank.IsFuelEnough(consumedFuel):
                    _car.MainWheel.Accelerate(direction);
                    _car.FuelTank.Consume(consumedFuel);
                    break;
                case 0 when velocity.magnitude < VelocityEpsilon:
                    _car.MainWheel.StopBraking();
                    break;
                case 0 when velocity.x > VelocityEpsilon:
                    _car.MainWheel.SlowDown();
                    break;
            }
        }
    }
}