﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenMan : MonoBehaviour
{
    public static ScreenMan Me;
    private void Awake()
    {
        Me = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void GoToLevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");
    }
    public void GotoGame()
    {
        SceneManager.LoadScene("Game");
    }

}