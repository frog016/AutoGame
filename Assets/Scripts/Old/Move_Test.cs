using UnityEngine;

namespace Old
{
    public class Move_Test : MonoBehaviour
    {
        public float speed = 10f;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            transform.position = transform.position + move * speed * Time.deltaTime;
        }
    }
}