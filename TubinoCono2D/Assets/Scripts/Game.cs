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
    private void Awake()
    {
        Me = this;
        levelMan = this.GetComponent<LevelMan>();
    }

    private void Start()
    {
        StartNewGame();
    }

    public void StartNewGame()
    {
        isPlaying = true;
        this.score = 0;
        levelMan.StartGeneration();
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
