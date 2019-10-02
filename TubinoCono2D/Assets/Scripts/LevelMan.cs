using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public List<Horda> hordas;
    public Level(List<Horda> _hordas)
    {
        this.hordas = _hordas;
    }
}
public class Horda
{
    public int[] patterns;
    public Horda(int[] _patterns)
    {
        this.patterns = _patterns;
    }

}

public class LevelMan : MonoBehaviour
{
    //public int level = 0;
    bool generating = false;
    public EnemyFactory enemyFactory;
    public GameWeights gw;
    public Level level;
    //public List<Level> levels;
    //public List<Horda>
    //public int[] lvl1 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };


    private void Awake()
    {
        enemyFactory = new EnemyFactory(this, gw);
        enemyFactory.Initialize();
    }

    


    public Level CreateLevel1()
    {
        List<Horda> lvl1 = new List<Horda>();
        lvl1.Add(new Horda(new int[9] { 0, 0, 0, -1, -1, -1, -1, -1, -1 }));
        lvl1.Add(new Horda(new int[9] { 0, -1, -1, -1, 0, -1, -1, -1, 0 }));
        lvl1.Add(new Horda(new int[9] { 0, -1, -1, -1, -1, -1, -1, -1, 0 }));
        lvl1.Add(new Horda(new int[9] { 0, 0, -1, 0, 0, -1, -1, -1, -1 }));
        lvl1.Add(new Horda(new int[9] { 0, -1, 0, -1, -1, -1, 0, -1, 0 }));
        lvl1.Add(new Horda(new int[9] { 0, 0, 0, 0, 0, 0, -1, -1, -1 }));
        lvl1.Add(new Horda(new int[9] { 0, 0, 0, 0, 1, 0, 0, 0, 0 }));
        return new Level(lvl1);
    }
    public void StartGeneration(int lvl)
    {
        switch (lvl)
        {
            case 1:
                level = CreateLevel1();
                break;
            case 2:
                level = CreateLevel1();
                break;
            case 3:
                level = CreateLevel1();
                break;
            case 4:
                level = CreateLevel1();
                break;
            case 5:
                level = CreateLevel1();
                break;
            case 6:
                level = CreateLevel1();
                break;
            case 7:
                level = CreateLevel1();
                break;
            case 8:
                level = CreateLevel1();
                break;
            case 9:
                level = CreateLevel1();
                break;
            case 10:
                level = CreateLevel1();
                break;
            case 11:
                level = CreateLevel1();
                break;
            case 12:
                level = CreateLevel1();
                break;
            case 13:
                level = CreateLevel1();
                break;
            case 14:
                level = CreateLevel1();
                break;           
            default:
                break;
        }
        this.generating = true;
        enemyFactory.Create(level);
    }
    public void StopGeneration()
    {
        this.generating = false;
        enemyFactory.Stop();
    }
    void Update()
    {
        if (!generating)
            return;

        
    }


}
