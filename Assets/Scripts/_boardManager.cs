using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _boardManager : MonoBehaviour
{
    public bool puzzleOneComplete = false;
    public bool puzzleTwoComplete = false;
    public bool puzzleThreeComplete = false;

    private Image puzzleOneIcon;
    private Image puzzleTwoIcon;
    private Image puzzleThreeIcon;

    public GameObject canvas;
    public GameObject playerPrefab;

    private GameObject spawn;
    private GameObject cam;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        Instantiate(canvas, transform.position, Quaternion.identity);
    }

    void Update()
    {
        

        if (puzzleOneComplete)
        {
            puzzleOneIcon = GameObject.Find("Task1").GetComponent<Image>();
            puzzleOneIcon.color = Color.red;
        }

        if (puzzleTwoComplete)
        {
            puzzleOneIcon = GameObject.Find("Task2").GetComponent<Image>();
            puzzleOneIcon.color = Color.green;
        }

        if (puzzleThreeComplete)
        {
            puzzleOneIcon = GameObject.Find("Task3").GetComponent<Image>();
            puzzleOneIcon.color = Color.blue;
        }
    }
}
