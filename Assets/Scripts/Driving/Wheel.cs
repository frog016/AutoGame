using System;
using UnityEngine;

namespace Driving
{
    public class Wheel
    {
        public Vector2 Velocity => _wheelJoint.attachedRigidbody.velocity;

        private readonly float _maxSpeed;
        private readonly float _acceleration;
        private readonly float _radius;
        private readonly WheelJoint2D _wheelJoint;

        public Wheel(float maxSpeed, float acceleration, float radius, WheelJoint2D wheelJoint)
        {
            _maxSpeed = maxSpeed;
            _acceleration = acceleration;
            _radius = radius;
            _wheelJoint = wheelJoint;

            ConfigureJoint();
        }

        public void Accelerate(int direction)
        {
            if (direction is > 1 or < -1)
                throw new ArgumentOutOfRangeException($"Direction must be 1 or -1.");

            _wheelJoint.useMotor = true;
            var motor = _wheelJoint.motor;
            var acceleration = ConvertLinearToAngle(_acceleration);
            var speed = Mathf.Abs(motor.motorSpeed);
            var reversDirection = -direction;

            motor.motorSpeed = reversDirection * Mathf.Clamp(speed + acceleration * Time.fixedDeltaTime, 0, ConvertLinearToAngle(_maxSpeed));
            _wheelJoint.motor = motor;
        }

        public void Brake()
        {
            _wheelJoint.useMotor = false;
            var motor = _wheelJoint.motor;
            motor.motorSpeed = 0f;
            _wheelJoint.motor = motor;
        }

        private void ConfigureJoint()
        {
            var motor = _wheelJoint.motor;
            motor.maxMotorTorque = ConvertLinearToAngle(_maxSpeed);
            _wheelJoint.motor = motor;
        }

        private float ConvertLinearToAngle(float value)
        {
            return value * _radius * Mathf.PI * Mathf.Rad2Deg;
        }
    }
}