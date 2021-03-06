﻿using System.Collections;
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

    public int ammo;
    public int health;

    public bool puzzleActive = false;

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
        if (health <= 0)
        {
            SceneManager.LoadScene("Death");
            Destroy(gameObject);
        }

        if (puzzleOneComplete && puzzleTwoComplete && puzzleThreeComplete)
        {
            SceneManager.LoadScene("Win");
            Destroy(gameObject);
        }

        if (puzzleOneComplete)
        {
            puzzleOneIcon = GameObject.Find("Task1").GetComponent<Image>();
            puzzleOneIcon.color = Color.white;
        }

        if (puzzleTwoComplete)
        {
            puzzleOneIcon = GameObject.Find("Task2").GetComponent<Image>();
            puzzleOneIcon.color = Color.white;
        }

        if (puzzleThreeComplete)
        {
            puzzleOneIcon = GameObject.Find("Task3").GetComponent<Image>();
            puzzleOneIcon.color = Color.white;
        }
    }
}
