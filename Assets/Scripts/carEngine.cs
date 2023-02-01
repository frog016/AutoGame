using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class carEngine : Car
{
 
    float direction;
    private float accelTime;
    private float frictionTime;
    private float deaccelTime;
    private float consumeTime;
    private float overSpeedTime; // damage over time using max speed
    

    [SerializeField]
    Rigidbody2D backWheelBody;
    [SerializeField]
    Rigidbody2D frontWheelBody;

    [SerializeField]
    Transform groundPointer;

    [SerializeField]
    LayerMask ground;
    
    [SerializeField]
    bool m_Grounded;
   
    bool fallDmg = true;
    //boost
    void Awake()
    {
        accelTime = Intervals[0];
        frictionTime = Intervals[1];
        deaccelTime = Intervals[2];
        consumeTime = Intervals[3];
        overSpeedTime = Intervals[4];
        CarBody = this.GetComponent<Rigidbody2D>();
        FuelBar =  GameObject.FindWithTag("FuelBar").GetComponent<Slider>();
        HpBar =  GameObject.FindWithTag("HpBar").GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        InitalSpeed = Speed;
       //backWheelBody.drag=15f;
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.DrawRay(groundPointer.position, new Vector2(0,-2f), Color.green);
        m_Grounded = IsGrounded();

        AccelAndDeaccel();

        if(m_Grounded)
        {
            fallDmg = true;

            DamageOverTimeMaxSpeed();

            if (frictionTime > 0 && !engineOn)
            {
                frictionTime -= Time.deltaTime;
            }
            else if (frictionTime < 0 && !engineOn)
            {
                frictionTime += Intervals[1];
                if (CarBody.velocity.x >= 3)
                {
                    CarBody.velocity = new Vector2(CarBody.velocity.x - 3f, CarBody.velocity.y - 3f);
                }
                else if (CarBody.velocity.x < 0.5f)
                {
                    CarBody.velocity = new Vector2(0, 0); //stop all movement
                    Speed = InitalSpeed;
                }
            }

            if (brakesOn && CarBody.velocity.x > 3f)
            {
                //Debug.Log("brake");
                //CarBody.velocity = new Vector2(CarBody.velocity.x - 3f, CarBody.velocity.y-3f);

                backWheelBody.GetComponent<WheelCollider>().brakeTorque = 300;
            }
            else if (brakesOn && CarBody.velocity.x < 0.1f && CarBody.velocity.y < 0.7f)
            {
                /* backWheelBody.drag=15f;
                frontWheelBody.drag=15f; */
            }
            else if (CarBody.velocity.y < 0.3f)
            {/* 
                backWheelBody.drag=2f;
                frontWheelBody.drag=2f; */
            }
        }
        else
        {
            if(CarBody.velocity.y < -10f && fallDmg)
            {
                Debug.Log(CarBody.velocity.y);
                HpBar.value -= 0.05f;
                fallDmg = false;
            }
            backWheelBody.drag=0f;
            frontWheelBody.drag=0f;
        }
        
    }

   

    private void AccelAndDeaccel()
    {
        if (accelTime > 0 && engineOn)
        {
            accelTime -= Time.deltaTime;
        }
        else if (accelTime <= 0 && engineOn)
        {
            accelTime += Intervals[0];
            if (Speed < MaxSpeed)
            {
                Speed += Accel;
            }
        }
        else if (accelTime < Intervals[0] && !engineOn)
        {
            accelTime = Intervals[0];
        }

        if (deaccelTime > 0 && !engineOn)
        {
            deaccelTime -= Time.deltaTime;
        }
        else if (accelTime <= 0 && !engineOn)
        {
            deaccelTime += Intervals[2];
            if (Speed < MaxSpeed)
            {
                Speed -= Accel / 2;
            }
        }
        else if (accelTime < Intervals[2] && engineOn)
        {
            deaccelTime = Intervals[2];
        }

    }

    void FixedUpdate()
    {
        if(engineOn)
        {        
           BackWheel.useMotor=true;
           FrontWheel.useMotor=true;
           JointMotor2D motor = new JointMotor2D{motorSpeed = Speed*direction , maxMotorTorque = 10000};
           BackWheel.motor=motor;
           FrontWheel.motor=motor;
          
           
            if (consumeTime > 0 )
            {
                consumeTime -= Time.deltaTime;
            }
            else
            {
                ConsumeFuel();

                consumeTime += Intervals[3];
            }
        }
        else
        {
           //BackWheel.useMotor=false;
           //FrontWheel.useMotor=false;
        }
        if(FuelTank<=0)
        {
            GameObject.FindWithTag("DeathMenu").transform.GetChild (0).gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
         FuelBar.value = FuelTank/MaxFuelTank;
    }

    public void ConsumeFuel()
    {
        FuelTank -= FuelConsume * 100;
    }

    public void EngineTurnOn(bool forward)
   {    
        engineOn=!engineOn;
        if(forward)
        {
            direction=1;
        }
        else
        {
            direction=-1;
        }
        if(engineOn == false)
        {
            consumeTime = Intervals[3];
        }

   }
   public void BrakesTurnOn()
   {    
        brakesOn=!brakesOn;
   }
   public bool IsGrounded() 
    {
     return Physics2D.Raycast(groundPointer.position, new Vector2(0,-2f), 1f, ground);
    }

    public void ConsumeFaster()
    {
        Intervals[3]-=0.2f;
        Debug.Log(consumeTime);
    }

     private void DamageOverTimeMaxSpeed()
    {
        if (overSpeedTime > 0 && Speed == MaxSpeed)
        {
            overSpeedTime -= Time.deltaTime;
        }
        else if (overSpeedTime < 0 && Speed == MaxSpeed)
        {
            overSpeedTime = Intervals[4];
            HpBar.value -= 0.02f;
        }
    }
}

