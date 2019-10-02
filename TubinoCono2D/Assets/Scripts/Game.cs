using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int currentHord = 0;
    public LevelMan levelMan;
    public static Game Me;
    public Text scoreTxt;

    public int lifes = 3;
    public int score = 0;
    public Hearts hearts;

    public LevelClearPopup levelClearPopup;
    public GameOverPopup gameOverPopup;
    private void Awake()
    {
        Me = this;
        levelMan = this.GetComponent<LevelMan>();
    }

    public void LevelClear()
    {
        levelClearPopup.Open();
    }

    private void Start()
    {
        StartNewGame();
    }

    public void StartNewGame()
    {
        isPlaying = true;
        this.score = 0;
        levelMan.StartGeneration(WorldMan.Me.currentLevel);
    }


    public void OnEnemyDie(Enemy enemy)
    {
        levelMan.enemyFactory.ReportDie(enemy);
        this.score++;
        this.scoreTxt.text = "" + score;
            
    }

    public void OnGameOver()
    {
        isPlaying = false;
        levelMan.StopGeneration();
        gameOverPopup.Open();
    }

    public bool isPlaying = false;

    public void ReportPass(Enemy enemy)
    {
        levelMan.enemyFactory.ReportDie(enemy);

        lifes--;
        if (lifes <= 0)
        {
            lifes = 0;
            OnGameOver();
        }

        hearts.UpdateLives(lifes);



    }
}
