using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform player;
    public float verticalSpeed;
    public float horizontalSpeed;

    public float health;

    void Start()
    {
        player = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            player.Translate(Vector2.up * verticalSpeed, Space.World);
        }
        if (Input.GetKey("s"))
        {
            player.Translate(Vector2.down * verticalSpeed, Space.World);
        }
        if (Input.GetKey("a"))
        {
            player.Translate(Vector2.left * horizontalSpeed, Space.World);
        }
        if (Input.GetKey("d"))
        {
            player.Translate(Vector2.right * horizontalSpeed, Space.World);
        }
    }
}
