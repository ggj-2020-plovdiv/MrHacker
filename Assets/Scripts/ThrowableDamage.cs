using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableDamage : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<GuardBehaviour>().health -= damage;
            Destroy(this.gameObject);
        }
    }
}
