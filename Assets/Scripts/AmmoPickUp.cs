using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }

            player.GetComponent<PlayerController>().ammo++;
            Destroy(this.gameObject);
        }
    }
}
