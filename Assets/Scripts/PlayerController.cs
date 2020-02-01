﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Transform player;
    public float verticalSpeed;
    public float horizontalSpeed;

    public float health;
    public Text healthText;

    public int ammo;
    public Text ammoText;

    public bool canMove = true;

    private int timesLeftMoved = 0;
    private int timesRightMoved = 0;
    private int timesRequredToMoveToBreakStun = 5;

    void Start()
    {
        player = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (canMove)
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
        else
        {
            if (Input.GetKeyDown("o"))
            {
                timesLeftMoved++;
                    
            }
            if (Input.GetKeyDown("p"))
            {
                timesRightMoved++;
            }

            if (timesLeftMoved >= timesRequredToMoveToBreakStun && timesRightMoved >= timesRequredToMoveToBreakStun)
            {
                canMove = true;
                timesLeftMoved = 0;
                timesRightMoved = 0;
                var enemies = GameObject.FindGameObjectsWithTag("Enemy");
                var distanse = Mathf.Infinity;
                GameObject closestEnemy = null;
                foreach (var enemy in enemies)
                {
                    var diff = enemy.transform.position - transform.position;
                    float currDistance = diff.sqrMagnitude;
                    if (currDistance < distanse)
                    {
                        closestEnemy = enemy;
                        distanse = currDistance;
                    }
                }
                if (closestEnemy.GetComponent<GuardBehaviour>().facingLeft)
                {
                    closestEnemy.transform.position = new Vector2(closestEnemy.transform.position.x + 1, closestEnemy.transform.position.y);
                }
                else if (closestEnemy.GetComponent<GuardBehaviour>().facingRight)
                {
                    closestEnemy.transform.position = new Vector2(closestEnemy.transform.position.x - 1, closestEnemy.transform.position.y);
                }
                closestEnemy.GetComponent<GuardBehaviour>().timeStunned = Time.time;
                closestEnemy.GetComponent<GuardBehaviour>().stunned = true;
            }
        }

        if (healthText != null)
        {
            healthText.text = $"Health: {health}";
        }

        if (ammoText != null)
        {
            ammoText.text = $"Ammo: {ammo}";
        }
    }
}
