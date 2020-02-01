using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerDetectedPlayer : MonoBehaviour
{
    private bool isComputerHacked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D()
    {
        Debug.Log("Press \"F\" to hack the computer...");
        if (Input.GetKeyDown("f") )
        {
            if (isComputerHacked != true)
            {
                Debug.Log("Computer was hacked!");
                isComputerHacked = true;
            }
            else
            {
                Debug.Log("You have done here! Go forward...");
            }
            
        }
    }
}
