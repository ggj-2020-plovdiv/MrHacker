using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public Texture2D targetCursor;
    public List<GameObject> throwablesGO;
    public GameObject go;

    public bool selectedThrowable = false;

    public GameObject player;

    public GameObject shootPrompt;
    public GameObject outOfAmmoPrompt;

    Animator playerAnimator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shootPrompt.SetActive(false);

        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (selectedThrowable && player.GetComponent<PlayerController>().canMove)
        {
            shootPrompt.SetActive(true);
            if (Input.GetButtonDown("Fire1") && player.GetComponent<PlayerController>().ammo > 0)
            {
                var foo = Instantiate(go, player.transform.position, Quaternion.identity);
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
                selectedThrowable = false;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                player.GetComponent<PlayerController>().ammo--;
                shootPrompt.SetActive(false);
                playerAnimator.Play("hacker_throw");
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                go = null;
                selectedThrowable = false;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                shootPrompt.SetActive(false);
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

    public void SelectedThrowable(string name)
    {
        Cursor.SetCursor(targetCursor, Vector2.zero, CursorMode.Auto);
        switch (name)
        {
            case "Vase":
                go = throwablesGO.Find(x => x.gameObject.name == "VaseThrowable");
                break;
            default:
                Debug.Log("No game object.");
                return;
        }

        selectedThrowable = true;
    }
}
