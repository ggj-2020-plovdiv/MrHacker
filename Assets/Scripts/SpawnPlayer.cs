using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;

    private GameObject cam;

    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        cam.GetComponent<CameraFollowPlayer>().player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }
}
