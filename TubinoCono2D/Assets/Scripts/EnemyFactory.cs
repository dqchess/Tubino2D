using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory: Factory
{
    GameObject levelContainer;
    bool familyIncomplete = false;
    int tempoFamilyId = -1;
    int acumFamily = 0;
    int limitFamily = 0;
    List<Enemy> cHorda = new List<Enemy>();
    List<Protestante> cPulptines = new List<Protestante>();

    public EnemyFactory(LevelMan _levelGenerator, GameWeights _gameWeights):base(_levelGenerator, _gameWeights)
    {
        cHorda = new List<Enemy>();
        cPulptines = new List<Protestante>();


    }

    bool canGenerate = false;

    public void Initialize()
    {
        this.canGenerate = true;
    }
    public void Stop()
    {
        this.canGenerate = false;
    }

    public void ResetFactory()
    {
        familyIncomplete = false;
        tempoFamilyId = -1;
        acumFamily = 0;
        limitFamily = 0;
    }

    int currentHorda = 0;
    public Vector3 initialpos = new Vector3(-2,6,0);
    public List<Vector3> offsets = new List<Vector3>() {
        new Vector3(0,0,0) ,
        new Vector3(1,0,0) ,
        new Vector3(2,0,0) ,
        new Vector3(3,0,0) ,
        new Vector3(4,0,0) ,

        new Vector3(0,2,0) ,
        new Vector3(1,2,0) ,
        new Vector3(2,2,0) ,
        new Vector3(3,2,0) ,
        new Vector3(4,2,0) ,

        new Vector3(0,4,0) ,
        new Vector3(1,4,0) ,
        new Vector3(2,4,0) ,
        new Vector3(3,4,0) ,
        new Vector3(4,4,0) ,

        new Vector3(0,6,0) ,
        new Vector3(1,6,0) ,
        new Vector3(2,6,0) ,
        new Vector3(3,6,0) ,
        new Vector3(4,6,0) ,

        new Vector3(0,8,0) ,
        new Vector3(1,8,0) ,
        new Vector3(2,8,0) ,
        new Vector3(3,8,0) ,
        new Vector3(4,8,0) ,

      
    };

    Level level;
    public void Create(Level _level)
    {
        this.level = _level;
        NextHorda();
        
    }

    void NextHorda()
    {
        if (!this.canGenerate)
            return;

        if (currentHorda == level.hordas.Count)
        {
            Game.Me.LevelClear();
            return;
        }


        cPulptines.Clear();
        cHorda.Clear();
        for (int i = 0; i < level.hordas[currentHorda].patterns.Length; i++)
        {
            if (level.hordas[currentHorda].patterns[i] >= 0)
            {
                if(level.hordas[currentHorda].patterns[i] == 3 || level.hordas[currentHorda].patterns[i] == 5 || level.hordas[currentHorda].patterns[i] == 19)
                {
                    GameObject protestante = TrashMan.spawn(gameWeights.enemy[level.hordas[currentHorda].patterns[i]].name);
                    Protestante e = protestante.GetComponent<Protestante>();
                    e.GetComponent<Protestante>().Initialize(gameWeights.enemy[level.hordas[currentHorda].patterns[i]].parameter);
                    protestante.transform.position = initialpos + offsets[i];
                    cPulptines.Add(e);
                }
                else
                {
                    GameObject enemy = TrashMan.spawn(gameWeights.enemy[level.hordas[currentHorda].patterns[i]].name);
                    Enemy e = enemy.GetComponent<Enemy>();
                    e.GetComponent<Enemy>().Initialize(gameWeights.enemy[level.hordas[currentHorda].patterns[i]].parameter);
                    enemy.transform.position = initialpos + offsets[i];
                    //Debug.Log(initialpos + offsets[i] + "  " + offsets[i]);
                    cHorda.Add(e);
                }
               
            }           
        }
        currentHorda++;
        
    }


    /*public void FillEnemy(Spawns _spawns, int meters)
    {
        for (int s = 0; s < _spawns.spawns.Count; s++)
        {
            int res = GetOneID(gameWeights.enemy, meters);
            GameObject enemy = TrashMan.spawn(gameWeights.enemy[res].name);

            Enemy e = enemy.GetComponent<Enemy>();
            e.GetComponent<Enemy>().Initialize(); 
            enemy.transform.position = _spawns.spawns[s].position;

            cHorda.Add(e);
        }

        TrashMan.despawn(_spawns.gameObject);
    }*/

    public void ReportDie(Enemy enemy)
    {
        enemy.isDie = true;
        bool endHorda = CheckEnemies();
        bool endPulpines = CheckPulpines();
        

        if (endHorda && endPulpines)
            NextHorda();
    }

    public void ReportDie(Protestante protestante)
    {
        protestante.isDie = true;
        bool endHorda = CheckEnemies();
        bool endPulpines = CheckPulpines();


        if (endHorda && endPulpines)
            NextHorda();
    }

    

    bool CheckEnemies()
    {
        bool endHorda = true;
        for (int i = 0; i < cHorda.Count; i++)
        {
            endHorda = cHorda[i].isDie;
            if (!endHorda)
                break;
        }
        return endHorda;

    }

    bool CheckPulpines()
    {
        bool endPulpines = true;
        for (int i = 0; i < cPulptines.Count; i++)
        {
            endPulpines = cPulptines[i].isDie;
            if (!endPulpines)
                break;
        }

        return endPulpines;
    }

    public int countHorda = 0;

    public void Remove(bool createOther)
    {
        
    }

   
}
