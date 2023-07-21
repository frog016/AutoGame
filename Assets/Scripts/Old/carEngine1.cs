using UnityEngine;

namespace Old
{
    public class carEngine1 : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        public bool engineOn = false;

        float timeToPeak = 2f;
        float timeTobrake = 5f;

        [SerializeField]
        Rigidbody2D carBody;

        [SerializeField]
        Animator backTireAnim;
        [SerializeField]
        Animator frontTireAnim;

        //boost
        void Awake()
        {
    
        }
        // Start is called before the first frame update
        void Start()
        {
            //carBody.velocity=new Vector3(100f, 0, 0);;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        void FixedUpdate()
        {
            backTireAnim.speed = ( (speed-15)/35)*1;
            frontTireAnim.speed = ( (speed-15)/35)*1;
            if(engineOn)
            {
                if(carBody.velocity.x > 0)
                {
                    backTireAnim.SetBool("engineOn",true);
                    frontTireAnim.SetBool("engineOn",true);
                
                }
                if(timeToPeak>0)
                {
                    timeToPeak-=Time.fixedDeltaTime;
                }
                else if (speed <50 && timeToPeak <=0)
                {
                    speed++;
                
                    carBody.velocity=new Vector3(speed, 0, 0);
                    timeToPeak=1f;
                }
                else
                {
                    //carBody.velocity=new Vector3(speed, 0, 0);
                }


           
                //backTire.useMotor=true;
                //FrontTire.useMotor=true;
                //backTire.AddTorque(torq*speed*Time.fixedDeltaTime);
                //rontTire.AddTorque(torq*speed*Time.fixedDeltaTime);
            }
            else
            {
                //backTire.useMotor=false;
                //FrontTire.useMotor=false;
                if(timeTobrake > 0)
                {
                    timeTobrake-=Time.fixedDeltaTime;
                }
                else if(speed > 15 && timeTobrake <= 0 )
                {
                    speed--;
                    timeTobrake=1f;
                    //carBody.velocity=new Vector3(speed, 0, 0);
                } 
          
            }
       
        }
        public void EngineTurnOn()
        {
            engineOn=!engineOn;

        }
    }
}
