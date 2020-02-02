using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    private _boardManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<_boardManager>();
            manager.puzzleActive = true;
        }
    }
}
