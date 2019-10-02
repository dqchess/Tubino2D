﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIGameScreen : MonoBehaviour
{
    public GameObject hudCoin;
    public Hearts hearts;
    public Text scoreTxt;
    public LevelClearPopup levelClearPopup;
    public GameOverPopup gameOverPopup;
    public PausePopup pausePopup;
    public Camera mycamera;
    public Canvas canvas;
    public Image levelClear;

    public void OnClickPause()
    {
        if(Game.Me.isPlaying)
            pausePopup.Open();
    }

    public void ShowLevelClear()
    {
        levelClear.gameObject.SetActive(true);
        levelClear.transform.localScale = Vector3.one;
        levelClear.transform.DOScale(1.5f, 0.3f).SetEase(Ease.InOutSine).SetLoops(2, LoopType.Yoyo).OnComplete(OnComPleteLevelClear);
    }

    public void OnComPleteLevelClear()
    {
        this.levelClear.gameObject.SetActive(false);
        this.levelClearPopup.Open();
    }
    
    public void SetScore(int value)
    {
        string s = "";
        if(value<10)
            s="000"+value;
        else if (value < 100)
            s = "00"+value;
        else if (value < 1000)
            s = "0"+value;
        else 
            s = ""+value;


        scoreTxt.text = s;

    }
    
}
