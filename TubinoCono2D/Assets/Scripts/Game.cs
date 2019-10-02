using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int currentHord = 0;
    public LevelMan levelMan;
    public static Game Me;

    public int lifes = 3;
    public int score = 0;


    public UIGameScreen ui;


    private void Awake()
    {
        Me = this;
        levelMan = this.GetComponent<LevelMan>();
    }

    public void LevelClear()
    {
        if (lifes > 0)
        {
            ES3.Save<int>("money", score);
            ui.levelClearPopup.Open();
            WorldMan.Me.SaveValues(lifes, true);
        }
        else
        {

        }
        
    }

    private void Start()
    {
        StartNewGame();
    }

    
    public void StartNewGame()
    {
        isPlaying = true;
        levelMan.StartGeneration(WorldMan.Me.currentLevel+1);
        score = ES3.Load<int>("money", 0);
        ui.scoreTxt.text = "" + score;
    }


    public void OnEnemyDie(Enemy enemy)
    {
        levelMan.enemyFactory.ReportDie(enemy);
        this.score++;
        this.ui.scoreTxt.text = "" + score;
            
    }

    public void OnGameOver()
    {
        if (isPlaying)
        {
            ES3.Save<int>("money", score);
            isPlaying = false;
            levelMan.StopGeneration();
            ui.gameOverPopup.Open();

        }
        
    }

    public bool isPlaying = false;

    public void ReportPass(Enemy enemy)
    {
        if (!isPlaying)
            return;

        levelMan.enemyFactory.ReportDie(enemy);

        lifes-=enemy.crush.life;
        if (lifes <= 0)
        {
            lifes = 0;
            OnGameOver();
        }

        ui.hearts.UpdateLives(lifes);



    }
}
