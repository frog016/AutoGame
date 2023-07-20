using UnityEngine;

namespace MapObjects
{
    public class MapObject : MonoBehaviour
    {
        [Header("Map Object")] 
        [SerializeField] private Vector3 spawnOffset;

        public Vector3 GetSpawnOffset() => spawnOffset;
    }
}
