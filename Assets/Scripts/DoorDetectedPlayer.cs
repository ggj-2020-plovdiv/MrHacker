using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetectedPlayer : MonoBehaviour
{
    public GameObject door1;

    public GameObject door2;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (player.GetComponent<PlayerController>().canMove)
        {
            if (Input.GetKeyDown("y"))
            {
                player.transform.position = new Vector2(door2.transform.position.x, door2.transform.position.y - 2.3f);
            }
        }

        if (gameObject.name == "Elevator")
        {
            Debug.Log(gameObject);
            var anim = transform.GetChild(0).GetComponent<Animator>();
            anim.SetBool("open", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.name == "Elevator")
        {
            var anim = transform.GetChild(0).GetComponent<Animator>();
            anim.SetBool("open", false);
        }
    }
}
