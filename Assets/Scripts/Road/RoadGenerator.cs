using System.Collections.Generic;
using MapObjects;
using UnityEngine;
using UnityEngine.U2D;
using Random = UnityEngine.Random;

namespace Road
{
    //[ExecuteInEditMode]
    public class RoadGenerator : MonoBehaviour
    {
        [SerializeField] private SpriteShapeController spriteShapeController;

        [SerializeField, Range(3f, 1000f)] private int levelLength = 50;
        [SerializeField, Range(1f, 50f)] private float xMultiplier = 2f;
        [SerializeField, Range(1f, 50f)] private float yMultiplier = 2f;
        [SerializeField, Range(0f, 1f)] private float curveSmoothness = 0.5f;
        [SerializeField] private float noiseStep = 0.5f;
        [SerializeField] private float bottom = 10f;

        [SerializeField] private List<GameObject> collectables;
        
        [SerializeField] private int obstacleFrequency;
        [SerializeField] private List<GameObject> obstacles;
        private Vector3 lastPos;

        private void OnValidate()
        {
            //GenerateLevel(false);
        }

        private void Start()
        {
            noiseStep = Random.Range(0.1f, 10.0f);
            GenerateLevel(true);
        }

        private void GenerateLevel(bool areObstSpawning)
        {
            spriteShapeController.spline.Clear();
            while (transform.childCount > 0) 
            {
                Destroy(transform.GetChild(0).gameObject);
            }
        
            for (var i = 0; i < levelLength; i++)
            {   
                lastPos = transform.position +
                          new Vector3(i * xMultiplier, Mathf.PerlinNoise(0, i * noiseStep) * yMultiplier);
                if (spriteShapeController.spline.GetPointCount() <= i)
                    spriteShapeController.spline.InsertPointAt(i, lastPos);

                if (Random.Range(0.0f, 1.0f) < 0.5f)
                {
                    var collectable = Instantiate(collectables[Random.Range(0, collectables.Count)], lastPos,
                        Quaternion.identity, transform);
                    collectable.transform.localPosition = lastPos + collectable.GetComponent<MapObject>().GetSpawnOffset();
                }
                
                if (areObstSpawning && i % obstacleFrequency == 0)
                {
                    // 0 - barrel, 1 - brick, 2 - gravel, 3 - hatch, 4 - policepost
                    var obstacle = Instantiate(obstacles[0], lastPos, Quaternion.identity, transform); 
                    //var obstacle = Instantiate(obstacles[Random.Range(0, obstacles.Count)], lastPos, Quaternion.identity, transform);
                    const float horizontalDifference = 3.0f;
                    obstacle.transform.localPosition = lastPos + new Vector3(horizontalDifference, 0.0f) + obstacle.GetComponent<MapObject>().GetSpawnOffset();
                    spriteShapeController.spline.InsertPointAt(i + 1, lastPos + new Vector3(horizontalDifference, 0.0f));
                    spriteShapeController.spline.InsertPointAt(i + 2, lastPos + new Vector3(2 * horizontalDifference, 0.0f));
                }
            }
        
            spriteShapeController.spline.InsertPointAt(levelLength, new Vector3(lastPos.x, transform.position.y - bottom));
            spriteShapeController.spline.InsertPointAt(levelLength + 1, new Vector3(transform.position.x, transform.position.y - bottom));

            var splinePointCount = spriteShapeController.spline.GetPointCount();
            for (var i = 0; i < splinePointCount; i++)
            {
                if (i == 0 || i == levelLength - 1) continue;
            
                spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                spriteShapeController.spline.SetLeftTangent(i, Vector3.left * xMultiplier * curveSmoothness);
                spriteShapeController.spline.SetRightTangent(i, Vector3.right * xMultiplier * curveSmoothness);
            }
        }
    }
}

