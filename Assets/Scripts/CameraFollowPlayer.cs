using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;

    public float leftBound;
    public float rightBound;
    public float upBound;
    public float downBound;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        if (player.transform.position.x <= leftBound)
        {
            this.transform.position = new Vector3(leftBound, this.transform.position.y, -10);
        }
        else if (player.transform.position.x >= rightBound)
        {
            this.transform.position = new Vector3(rightBound, this.transform.position.y, -10);
        }
        else
        {
            this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, -10);
        }

        if (player.transform.position.y >= upBound)
        {
            this.transform.position = new Vector3(this.transform.position.x, upBound, -10);
        }
        else if (player.transform.position.y <= downBound)
        {
            this.transform.position = new Vector3(this.transform.position.x, downBound, -10);
        }
        else
        {
            this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, -10);
        }
    }
}
