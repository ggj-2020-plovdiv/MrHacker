using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPuzzle : MonoBehaviour
{
    public _boardManager manager;

    public GameObject puzzle;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<_boardManager>();
        puzzle.SetActive(false);
    }

    void Update()
    {
        if (manager.puzzleActive)
        {
            puzzle.SetActive(true);
        } 
    }
}
