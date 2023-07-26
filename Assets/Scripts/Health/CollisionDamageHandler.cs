using System.Collections;
using System.Linq;
using UnityEngine;

namespace Health
{
    [RequireComponent(typeof(Driving.Car))]
    public class CollisionDamageHandler : MonoBehaviour
    {
        [SerializeField] private Vector2 _damageCoefficient;

        private bool _isCollizable = true;
        private IDamageable _carBody;

        private const float CollisionCheckDelay = 0.2f;

        private void Start()
        {
            var car = GetComponent<Driving.Car>();
            _carBody = car.Health;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_isCollizable == false)
                return;

            var collisionForce = GetCollisionForce(collision);
            var damage = Mathf.FloorToInt(Vector2.Scale(collisionForce, _damageCoefficient).magnitude);
            _carBody.ApplyDamage(damage);
            Debug.Log("Col damage: " + damage);
            
            StartCoroutine(Restart());
        }

        private IEnumerator Restart()
        {
            _isCollizable = false;
            yield return new WaitForSeconds(CollisionCheckDelay);
            _isCollizable = true;
        }

        private static Vector2 GetCollisionForce(Collision2D collision)
        {
            var mass = collision.rigidbody.mass;
            var maxVelocity = Vector2.zero;
            foreach (var contact in collision.contacts)
            {
                var projection = Vector3.Project(contact.relativeVelocity, contact.normal);
                if (projection.magnitude > maxVelocity.magnitude)
                    maxVelocity = projection;
            }

            return mass * Vector2.Scale(maxVelocity, maxVelocity);
        }
    }
}
