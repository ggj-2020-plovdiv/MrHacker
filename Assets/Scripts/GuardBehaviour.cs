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

    private float timeLastAttacked;
    private float attackCooldown = 1f;

    public bool facingLeft = false;
    public bool facingRight = true;

    public bool stunned = false;
    public float timeStunned;
    private float stunLenght = 2f;

    public int health;

    public Animator anim;

    void Start()
    {
        timeLastAttacked = Time.time;

        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {

        if (!stunned)
        {
            if (!chasing)
            {
                anim.SetBool("catched", false);
                Patrol();
            }
        }
        else
        {
            if (timeStunned + stunLenght < Time.time)
            {
                stunned = false;
                anim.SetBool("stunned", false);
            }
            else
            {
                anim.SetBool("stunned", true);
                anim.SetBool("catched", false);
            }
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
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
                transform.rotation = Quaternion.Euler(0, 180, 0);
                facingLeft = true;
                facingRight = false;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                facingLeft = false;
                facingRight = true;
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
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        var dist = Vector2.Distance(transform.position, player.transform.position);
        if (dist < 0.6f)
        {
            attacking = true;
            anim.SetBool("catched", true);
            player.GetComponent<PlayerController>().canMove = false;
            if (timeLastAttacked + attackCooldown < Time.time)
            {
                player.GetComponent<PlayerController>().health -= 10;
                timeLastAttacked = Time.time;
            }
        }
        else
        {
            attacking = false;
            player.GetComponent<PlayerController>().canMove = true;
        }

        if (!attacking)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
        }

    }
}
