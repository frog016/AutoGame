using UnityEngine;

namespace MapObjects.Obstacles
{
    public class FallingObstacleTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject obstacle;
        private float obstacleGravityScale;

        private void Awake()
        {
            obstacleGravityScale = obstacle.GetComponent<Rigidbody2D>().gravityScale;
            obstacle.GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("car"))
            {
                obstacle.GetComponent<Rigidbody2D>().gravityScale = obstacleGravityScale;
            }
        }
    }
}
