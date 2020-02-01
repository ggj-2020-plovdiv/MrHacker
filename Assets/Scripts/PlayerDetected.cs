using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected : MonoBehaviour
{
    public float rotationSpeed;

    private GameObject player;
    public GameObject parent;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SendMessageUpwards("ChasePlayer");
            parent.GetComponent<GuardBehaviour>().chasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SendMessageUpwards("CheckForDirChange");
            parent.GetComponent<GuardBehaviour>().chasing = false;
        }
    }
}
