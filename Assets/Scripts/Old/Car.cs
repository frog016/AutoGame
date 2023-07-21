using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Old
{
    public abstract class Car : MonoBehaviour
    {
        #region Specs
        [SerializeField]
        private float speed;

        [SerializeField]
        private float initalSpeed = 300;
        [SerializeField]
        private float maxSpeed= 2000;
        [SerializeField]
        private float accel = 50;
        [SerializeField]
        private float brakesPower = 150;

        [SerializeField]
        private float maxFuelTank = 100;

        [SerializeField]
        private float fuelTank = 100;
        [SerializeField]
        private float carHp = 100;

        [SerializeField]
        private float fuelConsume=100;
        #endregion
    
        [SerializeField]
        Slider fuelBar;
        [SerializeField]
        Slider hpBar;

        public bool engineOn = false;
        public bool brakesOn = false;

        #region Body
        Rigidbody2D carBody;
        [SerializeField]
        WheelJoint2D backWheel;
        [SerializeField]
        WheelJoint2D frontWheel;
        #endregion
    
        //[Header("Button Settings")]
        [Tooltip("accel, brakes, friction,deaccel")]
        [SerializeField]
        List<float> intervals= new List<float>(5); //accel friction deaccel dmgovertime

        #region SPECS GET SET
        public float Speed { get => speed; set => speed = value; }
        public float InitalSpeed { get => initalSpeed; set => initalSpeed = value; }
        public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
        public float Accel { get => accel; set => accel = value; }
        public float BrakesPower { get => brakesPower; set => brakesPower = value; }
        #endregion

        #region BODY GET SET
        public WheelJoint2D BackWheel { get => backWheel; set => backWheel = value; }
        public WheelJoint2D FrontWheel { get => frontWheel; set => frontWheel = value; }
        public Rigidbody2D CarBody { get => carBody; set => carBody = value; }
        public List<float> Intervals { get => intervals; set => intervals = value; }
        #endregion

        #region GAS GET SET
        public float FuelTank { get => fuelTank; set => fuelTank = value; }
        public float FuelConsume { get => fuelConsume; set => fuelConsume = value; }
        public Slider FuelBar { get => fuelBar; set => fuelBar = value; }

        public Slider HpBar { get => hpBar; set => hpBar = value; }
        public float MaxFuelTank { get => maxFuelTank; set => maxFuelTank = value; }
        #endregion

    }
}
