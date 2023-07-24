using ScriptableObject;
using UnityEngine;
using UnityEngine.UI;

namespace Old
{
    public class PlayerMovement : MonoBehaviour
    {

        Rigidbody2D rb2d;
        public int direction { get; set; }
        bool gasOn,brakesOn;

        [SerializeField]
        GameObject wheelVisuals1,wheelVisuals2;

        [SerializeField]
        CarSciptStats carSciptStats;
        [SerializeField]
        GameObject particleSmoke;
        const float _maxSpeedDuration = 2f;
        float _maxSpeedDurationCounter;

        const float _fuelConsumptionDuration = 2f;
        float _fuelConsumptionDurationCounter;

        [SerializeField]
        Transform groundPointer;

        [SerializeField]
        LayerMask ground;
    
        #region Specs
        private float speed;
    
        private float initalSpeed;
    
        private float maxSpeed;
    
        private float accelerationSpeed;
    
        private float decelerationSpeed;

        private float maxFuelTank;

        private float fuelTank;
    
        private float carHp;

        private float fuelConsumption;

        public Slider fuelBar;

        public Slider hpBar;

        bool fallDmg = true;
        #endregion
 
    
        // Start is called before the first frame update
        void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            GetStatFile();
            direction = 1;

            fuelBar =  GameObject.FindWithTag("FuelBar").GetComponent<Slider>();
            hpBar =  GameObject.FindWithTag("HpBar").GetComponent<Slider>();
        }

        private void FixedUpdate()
        {
            Move();
            Brakes();
            Rotate();

            if(IsGrounded())
            {
                fallDmg = true;
            }
            if (Mathf.Abs(rb2d.velocity.x) >= maxSpeed-0.2f)
            {
                MaxSpeedCountDown();  
            }
            else
            {
                _maxSpeedDurationCounter = _maxSpeedDuration;
            }

            if(Mathf.Abs(rb2d.velocity.x) > 0.5f)
            {
                FuelCountDown();
            }
            else
            {
                _fuelConsumptionDurationCounter = _fuelConsumptionDuration;
            }


            if(rb2d.velocity.y < -10f && fallDmg)
            {
                Debug.Log(rb2d.velocity.y + " fall dmg");
                hpBar.value -= 0.05f;
                fallDmg = false;
            }

            if(hpBar.value <0.5 )
            {
                particleSmoke.SetActive(true);
            }
            else
            {
                particleSmoke.SetActive(false);
            }

        }
        private void Move()
        {
            if(!gasOn)
            {
                return;
            }
        
            if (Mathf.Abs(rb2d.velocity.x) >= maxSpeed)
            {
                MaxSpeedCountDown();
            
                rb2d.velocity = new Vector2(maxSpeed * direction, rb2d.velocity.y);
            }
            else
            {
          
                rb2d.AddForce(transform.right * accelerationSpeed * direction, ForceMode2D.Force);
            }

        }

        private void Brakes()
        {
            if (!brakesOn)
                return;

            if(direction ==1)
            {
                if(rb2d.velocity.x > 0)
                {
                    rb2d.AddForce(transform.right * -1 * decelerationSpeed * direction, ForceMode2D.Force);
                }
                else
                {
                    rb2d.velocity = Vector2.zero;
                }
            }
            else
            {
                if (rb2d.velocity.x < 0)
                {
                    rb2d.AddForce(transform.right * -1 * decelerationSpeed * direction, ForceMode2D.Force);
                }
                else
                {
                    rb2d.velocity = Vector2.zero;
                }

            }    
            if(Mathf.Abs(rb2d.velocity.x) > 0)
            {
                rb2d.AddForce(transform.right*-1 * decelerationSpeed * direction, ForceMode2D.Force);
            }
            // if problem with brakes throw in update
            if((direction ==1 && rb2d.velocity.x <=0) || (direction==-1 && rb2d.velocity.x >=0))
            {
                rb2d.velocity = Vector2.zero;
            }
        }
        public void SetDirection(int newDirection)
        {
            direction = newDirection;
        }
        public void PressBrakes( bool newState)
        {
            brakesOn = newState;
        }
        public void PressGas(bool newState)
        {
            gasOn = newState;
        }

        private void Rotate()
        {
            wheelVisuals1.transform.Rotate(new Vector3(0, 0, direction * rb2d.velocity.x * -1f));
            wheelVisuals2.transform.Rotate(new Vector3(0, 0, direction * rb2d.velocity.x * -1f));
        }

        void GetStatFile()
        {
            speed= carSciptStats.speed;
            initalSpeed= carSciptStats.initalSpeed;
            maxSpeed= carSciptStats.maxSpeed;
            accelerationSpeed= carSciptStats.accelerationSpeed;
            decelerationSpeed= carSciptStats.decelerationSpeed;
            maxFuelTank= carSciptStats.maxFuelTank;
            fuelTank= carSciptStats.fuelTank;
            carHp= carSciptStats.carHp;
            fuelConsumption= carSciptStats.fuelConsumption;
        }

        void MaxSpeedCountDown()
        {
            if(_maxSpeedDurationCounter > 0 )
            {
                _maxSpeedDurationCounter-= Time.fixedDeltaTime;
            }
         
            else 
            {
                _maxSpeedDurationCounter = 0;
                //take damage
                Debug.Log("took dmg");
                hpBar.value -= 0.02f;
            }
        
        }

        void FuelCountDown()
        {
            if(_fuelConsumptionDurationCounter > 0 )
            {
                _fuelConsumptionDurationCounter-= Time.fixedDeltaTime;
            }
         
            else 
            {
                _fuelConsumptionDurationCounter = 0;
                //take damage
                Debug.Log("took fuel");
                fuelBar.value -= fuelConsumption;
            }
        
        }

        public bool IsGrounded() 
        {
            return Physics2D.Raycast(groundPointer.position, new Vector2(0,-2f), 1f, ground);
        }

        public void ChangeDirection()
        {
            direction*= -1;
        }

    }
}
