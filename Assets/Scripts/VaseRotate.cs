using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseRotate : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(0, 0, Time.deltaTime * 900f);
        Destroy(this.gameObject, 1.3f);
    }
}
