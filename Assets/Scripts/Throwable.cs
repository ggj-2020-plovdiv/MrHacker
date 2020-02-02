using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public GameObject vase;

    public GameObject player;

    public GameObject outOfAmmoPrompt;

    Animator playerAnimator;

    private float shootTime = 0f;
    private float shootCooldown = 1f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (player.GetComponent<PlayerController>().canMove)
        {
            if (Input.GetButtonDown("Fire1") && player.GetComponent<PlayerController>().ammo > 0 && shootTime + shootCooldown <= Time.time)
            {
                shootTime = Time.time;
                var foo = Instantiate(vase, player.transform.position, Quaternion.identity);
                foo.GetComponent<Rigidbody2D>().AddForce(transform.up * 300f);
                var playerScreenPoint = Camera.main.WorldToScreenPoint(player.transform.position);
                var mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                if (mouse.x < playerScreenPoint.x)
                {
                    foo.GetComponent<Rigidbody2D>().AddForce(transform.right * -200f);
                }
                else
                {
                    foo.GetComponent<Rigidbody2D>().AddForce(transform.right * 200f);
                }
                player.GetComponent<PlayerController>().ammo--;
                playerAnimator.Play("hacker_throw");
            }
        }

        player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<PlayerController>().ammo <= 0)
        {
            outOfAmmoPrompt.SetActive(true);
        }
        else
        {
            outOfAmmoPrompt.SetActive(false);
        }
    }
}
