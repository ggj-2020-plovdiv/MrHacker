using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour
{
    public Transform Destination;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerController>().canMove && Input.GetKeyDown("f"))
            {
                collision.gameObject.transform.position = new Vector2(Destination.position.x, Destination.position.y);
            }
        }
    }
}
