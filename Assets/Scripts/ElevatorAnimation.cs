using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorAnimation : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("open", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("open", false);
        }
    }
}
