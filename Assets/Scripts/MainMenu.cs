using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterInTheGame()
    {
        Debug.Log("cukna sa");
        SceneManager.LoadScene("Dechko");
    }

    public void ExitGame()
    {
        Debug.Log("Exitwaaa saaaa");
        Application.Quit();
    }
}
