using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidingSpot : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown("f"))
            {
                player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<PlayerController>().hiding = !player.GetComponent<PlayerController>().hiding;
            }
        }
    }
}
