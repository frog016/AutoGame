using System;
using Health;
using UnityEngine;

namespace Driving
{
    public class Car : MonoBehaviour
    {
        [field: SerializeField, Tooltip("Consumption per second")] public float FuelConsumption { get; private set; }

        [Tooltip("Meter per second"), SerializeField] private float _acceleration;
        [Tooltip("Meter per second"), SerializeField] private float _passiveDeceleration;
        [Tooltip("Meter per second"), SerializeField] private float _maxSpeed;
        [SerializeField] private float _fuelCapacity;
        [SerializeField] private int _maxHealth;
        [SerializeField] private float _wheelRadius;
        [SerializeField] private WheelJoint2D _mainWheelJoint;
        [SerializeField] private WheelJoint2D _secondWheelJoint;

        public FuelTank FuelTank { get; private set; }
        public Wheel MainWheel { get; private set; }
        public Wheel SecondWheel { get; private set; }
        public IDamageable Health { get; private set; }

        private void Awake()
        {
            MainWheel = new Wheel(_maxSpeed, _acceleration, _passiveDeceleration, _wheelRadius, _mainWheelJoint);
            SecondWheel = new Wheel(_maxSpeed, _acceleration, _passiveDeceleration, _wheelRadius, _secondWheelJoint);
            FuelTank = new FuelTank(_fuelCapacity);
            Health = new DamageableObject(_maxHealth);
        }
    }
}