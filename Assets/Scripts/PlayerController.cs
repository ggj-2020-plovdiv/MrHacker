using System;
using System.Collections;
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

    public bool hiding = false;

    GameObject go;

    public Animator anim;

    void Start()
    {
        player = GetComponent<Transform>();

        anim = gameObject.GetComponentInChildren<Animator>();

        go = this.gameObject;
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
        else
        {
            anim.SetBool("walking", false);
            BreakStun();
        }

        if (healthText != null)
        {
            healthText.text = $"Health: {health}";
        }
        else
        {
            healthText = GameObject.Find("HealthText").GetComponent<Text>();
        }

        if (ammoText != null)
        {
            ammoText.text = $"Vases: {ammo}";
        }
        else
        {
            ammoText = GameObject.Find("AmmoText").GetComponent<Text>();
        }

        Hide();
    }

    private void Hide()
    {
        //anim.SetBool("hiding", hiding);

        if (hiding)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -50);
            gameObject.layer = 4;
            canMove = false;
            if (Input.GetKeyDown("f"))
            {
                hiding = !hiding;
            }
        }
        else if (!hiding)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            gameObject.layer = 0;
            canMove = true;
        }
    }

    private void Move()
    {

        if (Input.GetKey("w"))
        {
            player.Translate(Vector2.up * verticalSpeed, Space.World);
            anim.SetBool("walking", true);
        }
        if (Input.GetKey("s"))
        {
            player.Translate(Vector2.down * verticalSpeed, Space.World);
            anim.SetBool("walking", true);
        }
        if (Input.GetKey("a"))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            player.Translate(Vector2.left * horizontalSpeed, Space.World);
            anim.SetBool("walking", true);
        }
        if (Input.GetKey("d"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            player.Translate(Vector2.right * horizontalSpeed, Space.World);
            anim.SetBool("walking", true);
        }

        
        if (Input.GetKeyUp("w"))
        {
            anim.SetBool("walking", false);
        }
        if (Input.GetKeyUp("s"))
        {
            anim.SetBool("walking", false);
        }
        if (Input.GetKeyUp("a"))
        {
            anim.SetBool("walking", false);
        }
        if (Input.GetKeyUp("d"))
        {
            anim.SetBool("walking", false);
        }
    }

    private void BreakStun()
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
}
