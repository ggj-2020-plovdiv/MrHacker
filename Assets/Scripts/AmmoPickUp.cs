using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    private GameObject player;

    private _boardManager manager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<_boardManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }

            manager.ammo++;
            Destroy(this.gameObject);
        }
    }
}
