using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetectedPlayer : MonoBehaviour
{
    public GameObject door1;

    public GameObject door2;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D()
    {
        Debug.Log("Player in front of the door.");
        Debug.Log("Enter \"y\" to open the door.");
        if (Input.GetKeyDown("y"))
        {
            player.transform.position = new Vector2(door2.transform.position.x, door2.transform.position.y);
        }
    }
}
