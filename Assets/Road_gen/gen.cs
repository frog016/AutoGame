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
    public Vector3[] vertices;

    public GameObject[] road_blocks;
    public int chance;
    public GameObject marker;

    // Start is called before the first frame update
    void Start()
    {
        edgeCollider2D = gameObject.GetComponent<EdgeCollider2D>();
        BezierPath path = GeneratePath(GeneratePoints(segmentCount, maxHeight, segmentDist));
        GetComponent<PathCreator>().bezierPath = path;
        GenerateCollider(path);
        CreateBackGroundMesh();
        BackgroundStretch();
        
    }

    Vector2[] GeneratePoints(int segmentCount, float maxHeight, float segmentDist){
        Vector2 point = GetComponent<Transform>().position;
        float len = segmentDist;
        List<Vector2> positions = new List<Vector2>();
        positions.Add(point);
        for(var i = 1; i < segmentCount; i++){
            if(Random.Range(0,100) < chance){
                float road_y = Random.Range(0, maxHeight);
                float road_x = point.x + len;
                var obj = Instantiate(road_blocks[Random.Range(0,road_blocks.Length)],new Vector2(road_x,road_y), new Quaternion());
                Vector2[] road = obj.GetComponent<prefab_data>().road;
                positions.Add(new Vector2(road_x,road_y + road[0].y));
                Instantiate(marker, new Vector2(road_x,road_y), new Quaternion());
                for (var j = 1; j < road.Length; j++){
                    float seg_len = road[j].x - road[j-1].y;
                    Debug.LogFormat(" Len {0}",seg_len);
                    positions.Add(new Vector2(road_x + seg_len,road_y+ road[j].y));
                    Instantiate(marker, new Vector2(road_x + seg_len,road_y+road[j].y), new Quaternion());
                    len += seg_len;
                    
                }
                len += segmentDist;
            }
            else{
                Vector2 new_point = new Vector2(point.x + len, Random.Range(0, maxHeight));
                len += segmentDist;
                positions.Add(new_point);
            }
        }
        return positions.ToArray();
    }

    BezierPath GeneratePath(Vector2[] points){
        BezierPath bezierPath = new BezierPath(points, false, PathSpace.xy);
        return bezierPath;
    }

    public void GenerateCollider(BezierPath path){
        VertexPath vertexPath = new VertexPath(path,this.transform,0.5f);
        int count = vertexPath.NumPoints;
        List<Vector2> list = new List<Vector2>();
        vertices = new Vector3[count];
        for (int i = 0; i < count; i++)
        {
            list.Add(vertexPath.GetPoint(i));
            vertices[i] = vertexPath.GetPoint(i);
        }
        edgeCollider2D.SetPoints(list);
        // visualise

    }
    public void BackgroundStretch(){
        SpriteRenderer rendrer =  background.GetComponent<SpriteRenderer>();
        Vector2 last = rendrer.size;
        last.x = vertices[vertices.Length - 1].x;
        Vector3 center = background.transform.position;
        center.x = last.x  / 2;
        background.transform.position = center;
        rendrer.size = last;
    }
    public void CreateBackGroundMesh(){
        Vector3[] meshVertices = new Vector3[vertices.Length * 6];
        int[] triangles = new int[((vertices.Length * 2) - 2) * 3];
        for (int i = 0; i < vertices.Length; i++){
            meshVertices[i] = vertices[i];
        }
        for (int i = 0; i < vertices.Length; i++){
            meshVertices[i+vertices.Length] = new Vector3(vertices[i].x, -30);
        }
        int counter = 0;
        for (int i = 0; i < ((vertices.Length * 2) - 2) * 3; i +=6){
            int len = vertices.Length;
            triangles[i] = counter;
            triangles[i + 1] = counter + 1;
            triangles[i + 2] = len + counter;
            triangles[i + 3] = len + counter;
            triangles[i + 4] = counter + 1;
            triangles[i + 5] = len + 1 + counter;
            counter++;
        }
        
        Mesh mesh = new Mesh();
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        mesh.vertices = meshVertices;
        mesh.triangles = triangles;
        meshFilter.mesh = mesh;

    }

}
