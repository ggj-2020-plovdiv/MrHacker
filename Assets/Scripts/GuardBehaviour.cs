using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehaviour : MonoBehaviour
{
    public float chaseSpeed;
    public float patrolSpeed;

    private GameObject player;

    public List<GameObject> patrolPoints;
    public bool chasing = false;
    public bool attacking = false;
    GameObject nextPoint;

    private int currentPoint = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        foreach (var point in GameObject.FindGameObjectsWithTag("PatrolPoint"))
        {
            patrolPoints.Add(point);
        }
    }

    void FixedUpdate()
    {
        if (!chasing)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        var pointsFromListToArray = patrolPoints.ToArray();
        var point = pointsFromListToArray[currentPoint];
        var distanceToPoint = Vector2.Distance(transform.position, point.transform.position);
        if (distanceToPoint > 0.1)
        {
            var pos = transform.position;
            transform.position = Vector2.MoveTowards(transform.position, point.transform.position, patrolSpeed * Time.deltaTime);
            if (pos.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, -180);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            if (currentPoint < pointsFromListToArray.Length - 1)
            {
                currentPoint++;
            }
            else
            {
                currentPoint = 0;
            }
        }
    }

    void ChasePlayer()
    {
        var dist = Vector2.Distance(transform.position, player.transform.position);
        if (dist < 0.6)
        {
            attacking = true;
        }
        else
        {
            attacking = false;
        }

        if (!attacking)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
        }

    }

    void CheckForDirChange()
    {
        var dist = Vector2.Distance(transform.position, player.transform.position);
        if (dist < 1f)
        {
            transform.Rotate(0, 0, 180);
        }
        else
        {
            chasing = false;
        }
    }
}
