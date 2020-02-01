using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidingSpot : MonoBehaviour
{
    public GameObject hideTextPrompt;

    private GameObject player;

    void Start()
    {
        hideTextPrompt = GameObject.FindGameObjectWithTag("HidePrompt");
        hideTextPrompt.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hideTextPrompt.SetActive(true);
        }
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hideTextPrompt.SetActive(false);
        }
    }
}
