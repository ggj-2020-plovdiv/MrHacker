using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehaviour : MonoBehaviour
{
    public float speed;

    private GameObject player;

    public List<GameObject> patrolPoints;
    public bool chasing = false;
    GameObject nextPoint;

    private bool foundAllPoints = false;
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
            transform.position = Vector2.MoveTowards(transform.position, point.transform.position, 1f * Time.deltaTime);
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
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 1f * Time.deltaTime);
    }

    void CheckForDirChange()
    {
        var dist = Vector2.Distance(transform.position, player.transform.position);
        if (dist < 1f)
        {
            transform.Rotate(0, 0, 180);
        }
    }
}
