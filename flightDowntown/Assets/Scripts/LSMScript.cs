﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LSMScript : MonoBehaviour
{
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //displays the highscore
        if (PlayerPrefs.HasKey("highScore"))
        {
            scoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //starts the game
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
