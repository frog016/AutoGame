using UnityEngine;

namespace Driving
{
    public class PolygonFix : MonoBehaviour
    {
        [SerializeField] private float _scale;
        [SerializeField] private PolygonCollider2D _collider;

        [ContextMenu(nameof(Fix))]
        public void Fix()
        {
            var points = new Vector2[_collider.points.Length];
            for (var i = 0; i < points.Length; i++)
                points[i] = _collider.points[i] * _scale;

            _collider.points = points;
        }
    }
}
