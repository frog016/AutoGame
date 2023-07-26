using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject carSpawner;
    private CinemachineVirtualCamera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        cam.Follow = carSpawner.transform.GetChild(0).transform;
    }
}
