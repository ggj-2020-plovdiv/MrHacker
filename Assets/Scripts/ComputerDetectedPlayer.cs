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

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        progressBar.fillAmount = 0f;
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

            if (Input.GetKey("f") && !buttonHeld)
            {
                timer += Time.deltaTime;

                progressBar.fillAmount += 1.0f / holdTime * Time.deltaTime;

                if (timer > (startTime + holdTime))
                {
                    buttonHeld = true;
                    ButtonHeld();
                }
            }

            if (Input.GetKeyUp("f"))
            {
                buttonHeld = false;
            }
        }
    }

    void ButtonHeld()
    {
        Debug.Log("held for " + holdTime + " seconds");
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
