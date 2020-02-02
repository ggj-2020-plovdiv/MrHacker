using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string levelName;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown("f"))
        {
            SceneManager.LoadScene($"{levelName}");
        }
    }
}
