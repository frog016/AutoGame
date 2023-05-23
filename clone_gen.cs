using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class gen : MonoBehaviour
{
    public EdgeCollider2D edgeCollider2D;

    public GameObject background;
    public int segmentCount;
    public float maxHeight;
    public float segmentDist;
    public Vector3[] vertexes;

    // Start is called before the first frame update
    void Start()
    {
        edgeCollider2D = gameObject.GetComponent<EdgeCollider2D>();
        BezierPath path = GeneratePath(generatePoints(segmentCount, maxHeight, segmentDist));
        GetComponent<PathCreator>().bezierPath = path;
        GenerateCollider(path);
        BackgroundStretch();
    }
    Vector2[] generatePoints(int segmentCount, float maxHeight, float segmentDist){
        Vector2 point = GetComponent<Transform>().position;
        float len = segmentDist;
        Vector2[] positions = new Vector2[segmentCount];
        positions[0] = point;
        for(var i = 1; i < segmentCount; i++){
            Vector2 new_point = new Vector2(point.x + len, Random.Range(0, maxHeight));
            len += segmentDist;
            positions[i] = new_point;
        }
        return positions;
    }

    BezierPath GeneratePath(Vector2[] points){
        BezierPath bezierPath = new BezierPath(points, false, PathSpace.xy);
        return bezierPath;
    }

    public void GenerateCollider(BezierPath path){
        VertexPath vertexPath = new VertexPath(path,this.transform,0.3f);
        int count = vertexPath.NumPoints;
        List<Vector2> list = new List<Vector2>();
        vertexes = new Vector3[count];
        for (int i = 0; i < count; i++)
        {
            list.Add(vertexPath.GetPoint(i));
            vertexes[i] = vertexPath.GetPoint(i);
        }
        edgeCollider2D.SetPoints(list);
        // visualise

    }
    public void BackgroundStretch(){
        SpriteRenderer rendrer =  background.GetComponent<SpriteRenderer>();
        Vector2 last = rendrer.size;
        last.x = vertexes[vertexes.Length - 1].x;
        Vector3 center = background.transform.position;
        center.x = last.x  / 2;
        background.transform.position = center;
        rendrer.size = last;
        Debug.Log(last);
    }

}
