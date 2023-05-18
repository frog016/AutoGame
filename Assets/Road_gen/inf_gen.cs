using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class inf_gen : MonoBehaviour
{
    public Vector3[] vertexes;
    public gen gen;
    public PlayerMovement player;
    public EdgeCollider2D edgeCollider2D;
    int l = 0;
    void Start()
    {
        edgeCollider2D = gameObject.GetComponent<EdgeCollider2D>();
        BezierPath path = GeneratePath(generatePoints(gen.segmentCount, gen.maxHeight, gen.segmentDist));
        GetComponent<PathCreator>().bezierPath = path;
        VertexPath vertexPath = new VertexPath(path, this.transform, 0.3f);
        int count = vertexPath.NumPoints;
        List<Vector2> list = new List<Vector2>();
        vertexes = new Vector3[count];
        for (int i = 0; i < count; i++)
        {
            list.Add(vertexPath.GetPoint(i));
            vertexes[i] = vertexPath.GetPoint(i);
        }
        edgeCollider2D.SetPoints(list);
    }
    Vector2[] generatePoints(int segmentCount, float maxHeight, float segmentDist)
    {
        Vector2 point = GetComponent<Transform>().position;
        float len = segmentDist;
        Vector2[] positions = new Vector2[segmentCount];
        positions[0] = point;
        for (var i = 1; i < segmentCount; i++)
        {
            Vector2 new_point = new Vector2(point.x + len, Random.Range(0, maxHeight));
            len += segmentDist;
            positions[i] = new_point;
        }
        return positions;
    }

    BezierPath GeneratePath(Vector2[] points)
    {
        BezierPath bezierPath = new BezierPath(points, false, PathSpace.xy);
        return bezierPath;
    }

    // Update is called once per frame
    void Update()
    {
        if (l == 0)
        {
            transform.position = new Vector3(transform.position.x + 1485, gen.vertexes[4969].y, 0);
            l += 1;
        }
        if (l % 2 == 0 && player.transform.position.x > (gen.transform.position.x + 500))
        {
            transform.position = new Vector3(gen.transform.position.x + 1485, gen.vertexes[gen.vertexes.Length-1].y, 0);
            l += 1;
        }
        if (l % 2 == 1 && player.transform.position.x > (transform.position.x + 500))
        {
            gen.transform.position = new Vector3(transform.position.x + 1485, vertexes[vertexes.Length-1].y, 0);
            l += 1;
        }
    }
}
