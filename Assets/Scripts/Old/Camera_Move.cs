using UnityEngine;

namespace Old
{
    public class Camera_Move : MonoBehaviour
    {
        [Header("Param")]
        [SerializeField] private Transform playerTransform;
        [SerializeField] private string playerTag;
        [SerializeField] private float movingSpeed;

        private void Awake()
        {
            if(this.playerTransform == null)
            {
                if(this.playerTag == "")
                {
                    this.playerTag = "Player";
                }

                this.playerTransform = GameObject.FindGameObjectWithTag(playerTag).transform; 
            }

            this.transform.position = new Vector3()
            {
                x = this.transform.position.x,
                y = this.transform.position.y,
                z = this.transform.position.z - 10,
            };
        }



        void Update()
        {
            if(this.playerTransform)
            {
                Vector3 target = new Vector3()
                {
                    x = this.playerTransform.position.x,
                    y = this.playerTransform.position.y,
                    z = this.playerTransform.position.z - 10,
                };

                Vector3 pos = Vector3.Lerp(this.transform.position, target, this.movingSpeed*Time.deltaTime);

                this.transform.position = pos;
            }
        }
    }
}
