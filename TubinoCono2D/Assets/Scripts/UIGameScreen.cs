using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void OnClickPause()
    {
        if(Game.Me.isPlaying)
            pausePopup.Open();
    }

}
