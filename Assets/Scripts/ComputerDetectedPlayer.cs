using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerDetectedPlayer : MonoBehaviour
{
    private bool isComputerHacked = false;

    private bool hackable = false;

    public GameObject player;

    public float startTime = 0f;
    public float timer = 0f;
    public float holdTime = 2f;

    private bool buttonHeld = false;

    public Image progressBar;

    private _boardManager manager;

    public Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        progressBar.fillAmount = 0f;

        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<_boardManager>();
    }

    void Update()
    {
        if (hackable && !isComputerHacked)
        {
            if (Input.GetKeyDown("f"))
            {
                startTime = Time.time;
                timer = startTime;
            }

            player = GameObject.FindGameObjectWithTag("Player");
            if (Input.GetKey("f") && !buttonHeld && player.GetComponent<PlayerController>().canMove)
            {
                timer += Time.deltaTime;

                progressBar.fillAmount += 1.0f / holdTime * Time.deltaTime;

                if (timer > (startTime + holdTime))
                {
                    buttonHeld = true;
                    ButtonHeld();
                }
            }
            else
            {
                buttonHeld = false;
                progressBar.fillAmount = 0f;
            }

            if (Input.GetKeyUp("f"))
            {
                buttonHeld = false;
                progressBar.fillAmount = 0f;
            }
        }

        if (isComputerHacked)
        {
            anim.SetBool("hacked", true);
        }
    }

    void ButtonHeld()
    {
        progressBar.fillAmount = 0f;
        manager.puzzleOneComplete = true;
        isComputerHacked = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hackable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hackable = false;
        }
    }
}
