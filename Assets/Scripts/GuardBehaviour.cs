using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehaviour : MonoBehaviour
{
    public float speed;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        
    }
    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 1f * Time.deltaTime);
    }

    void CheckForDirChange()
    {
        var dist = Vector2.Distance(transform.position, player.transform.position);
        if (dist < 2f)
        {
            transform.Rotate(0, 0, 180);
        }
    }
}
