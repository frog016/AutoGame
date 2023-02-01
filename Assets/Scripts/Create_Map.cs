using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Create_Map : MonoBehaviour
{
    public GameObject z1_1;
    public GameObject z2_1;
    public GameObject z3_1;
    public GameObject car;
    public GameObject z1;
    public GameObject z2;
    public GameObject z3;
    public GameObject z4;
    public GameObject z5;
    public GameObject z6;
    public GameObject z7;
    public GameObject z8;
    public GameObject z9;
    public GameObject z10;
    public GameObject cont;
    public bool first = true;
    private readonly int size = 4;
    public float CT = 43.5f;
    public int counter = 0;
    public float min_x = 0f;
    readonly Queue<GameObject> road = new();
   
    private void Start()
    {
        road.Enqueue(z1);
        CreateBase();
    }

    private void Update()
    {
        if (CT - car.transform.localPosition.x <= 25)
        {
            Generate();
            if (first)
            {
                Destroy(road.Peek());

                road.Dequeue();
            }
            else
            {
                first = true;
            }

            CT += 10;
            min_x += 10;
        }
        if (min_x > car.transform.localPosition.x)
        {
            car.transform.localPosition = new Vector3(min_x, car.transform.localPosition.y, car.transform.localPosition.z);
        }
        if (car.transform.localPosition.x >= 200)
        {
            PlayerPrefs.SetInt("num", 1);
            SceneManager.LoadScene(6);
        }
    }

    public void Generate()
    {
        GameObject cell = cont;
        float x = cell.transform.localPosition.x;
        float y = cell.transform.localPosition.y;
        int rand = Random.Range(1, 11);
        if (rand == 1)
        {
            int rnd = Random.Range(1, 2);
            if (rnd == 1)
            {
                cell = Instantiate(z1_1);
            }
            else
                cell = Instantiate(z1);
        }
        else if (rand == 2)
        {
            int rnd = Random.Range(1, 3);
            if (rnd == 1)
            {
                cell = Instantiate(z2_1);
            }
            else
                cell = Instantiate(z2);
        }
        else if (rand == 3)
            cell = Instantiate(z3);
        else if (rand == 4)
            cell = Instantiate(z4);
        else if (rand == 5)
            cell = Instantiate(z5);
        else if (rand == 6)
            cell = Instantiate(z6);
        else if (rand == 7)
            cell = Instantiate(z7);
        else if (rand == 8)
            cell = Instantiate(z8);
        else if (rand == 9)
            cell = Instantiate(z9);
        else if (rand == 10)
        {
            int rnd = Random.Range(1, 3);
            if (rnd == 1)
            {
                cell = Instantiate(z3_1);
            }
            else
                cell = Instantiate(z10);
        }

        cell.transform.localPosition = new Vector3(x + 10, y, 0);
        road.Enqueue(cell);
        cont = cell;
    }

    public void CreateBase()
    {
        GameObject cell = Instantiate(z1);
        if (first)
        {
            cell.transform.localPosition = new Vector3(0, 0, 0);
            first = false;
            counter++;
        }
        else
        {
            cell.transform.localPosition = new Vector3(cont.transform.localPosition.x + 10, 0, 0);
            counter++;
        }
        road.Enqueue(cell);
        cont = cell;
        if (counter < size)
            CreateBase();
    }
}
