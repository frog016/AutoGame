using System;
using UnityEngine;

namespace Driving
{
    public class Wheel
    {
        public Vector2 Velocity => _wheelJoint.attachedRigidbody.velocity;
        public Vector2 VelocityInKmph => Velocity * 3.6f;
        
        private readonly float _maxSpeed;
        private readonly float _acceleration;
        private readonly float _passiveDeceleration;
        private readonly float _radius;
        private readonly WheelJoint2D _wheelJoint;

        private float RotationAngle => Mathf.Clamp(_wheelJoint.transform.rotation.z, -90, 90);

        public Wheel(float maxSpeed, float acceleration, float passiveDeceleration, float radius, WheelJoint2D wheelJoint)
        {
            _maxSpeed = maxSpeed;
            _acceleration = acceleration;
            _radius = radius;
            _wheelJoint = wheelJoint;
            _passiveDeceleration = passiveDeceleration;

            ConfigureJoint();
        }

        public void Accelerate(int direction)
        {
            if (direction is > 1 or < -1)
                throw new ArgumentOutOfRangeException($"Direction must be 1 or -1.");

            var motor = _wheelJoint.motor;
            var acceleration = ConvertLinearToAngle(_acceleration) * Mathf.Cos(RotationAngle);
            var speed = Mathf.Abs(motor.motorSpeed);
            var reversDirection = -direction;

            motor.motorSpeed = reversDirection * Mathf.Clamp(speed + acceleration * Time.fixedDeltaTime, 0, ConvertLinearToAngle(_maxSpeed));
            _wheelJoint.motor = motor;
            _wheelJoint.useMotor = true;
        }

        public void SlowDown()
        {
            var motor = _wheelJoint.motor;

            var angleCoefficient = 1 + Mathf.Abs(Mathf.Sin(RotationAngle));
            var deceleration = ConvertLinearToAngle(_passiveDeceleration) * angleCoefficient;
            var speed = Mathf.Abs(motor.motorSpeed);
            var speedSign = Mathf.Sign(motor.motorSpeed);

            motor.motorSpeed = speedSign * Mathf.Max(0, speed - deceleration * Time.fixedDeltaTime);
            _wheelJoint.motor = motor;
        }

        public void Brake()
        {
            var motor = _wheelJoint.motor;
            motor.motorSpeed = 0f;
            _wheelJoint.motor = motor;
        }

        public void StopBraking()
        {
            _wheelJoint.useMotor = false;
        }

        private void ConfigureJoint()
        {
            var motor = _wheelJoint.motor;
            motor.maxMotorTorque = ConvertLinearToAngle(_maxSpeed);
            _wheelJoint.motor = motor;
        }

        private float ConvertLinearToAngle(float value)
        {
            var angularSpeed = value / _radius;
            return angularSpeed * Mathf.Rad2Deg;
        }

        private float ConvertAngleToLinear(float value)
        {
            var linearSpeed = value * _radius;
            return linearSpeed * Mathf.Deg2Rad;
        }
    }
}