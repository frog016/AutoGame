using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using Random = UnityEngine.Random;

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

    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private int obstacleFrequency;
    private Vector3 lastPos;

    private void OnValidate()
    {
        //GenerateLevel();
    }

    private void Start()
    {
        noiseStep = Random.Range(0.1f, 10.0f);
        GenerateLevel();
    }

    private void GenerateLevel()
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
            spriteShapeController.spline.InsertPointAt(i, lastPos);

            if (i != 0 && i != levelLength - 1)
            {
                spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                spriteShapeController.spline.SetLeftTangent(i, Vector3.left * xMultiplier * curveSmoothness);
                spriteShapeController.spline.SetRightTangent(i, Vector3.right * xMultiplier * curveSmoothness);
            }
            if (i % obstacleFrequency == 0)
                Instantiate(obstacles[Random.Range(0, obstacles.Count)], lastPos, Quaternion.identity, transform);
        }
        
        spriteShapeController.spline.InsertPointAt(levelLength, new Vector3(lastPos.x, transform.position.y - bottom));
        spriteShapeController.spline.InsertPointAt(levelLength + 1, new Vector3(transform.position.x, transform.position.y - bottom));
    }
}
