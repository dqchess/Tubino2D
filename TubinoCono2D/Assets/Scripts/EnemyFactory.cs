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

    public EnemyFactory(LevelMan _levelGenerator, GameWeights _gameWeights):base(_levelGenerator, _gameWeights)
    {
        cHorda = new List<Enemy>();

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

    public void Create(int meters)
    {
        if (!this.canGenerate)
            return;

        this.countHorda++;

        cHorda.Clear();   

        int res = 0;
       
        if (familyIncomplete)
        {
            if (this.acumFamily < this.limitFamily)
            {
                res = this.tempoFamilyId;
                this.acumFamily++;
            }
            else
            {
                res = GetOneID(gameWeights.levels, meters);
                this.familyIncomplete = false;
                this.tempoFamilyId = 0;
                this.acumFamily = 0;
                this.limitFamily = 0;
            }


        }
        else
        {
            res = GetOneID(gameWeights.levels, meters);
            if (gameWeights.levels[res].family.x > 1 || gameWeights.levels[res].family.y > 1)
            {
                familyIncomplete = true;
                int r = Random.Range(gameWeights.levels[res].family.x, gameWeights.levels[res].family.y + 1);
                this.tempoFamilyId = res;
                this.acumFamily = 1;
                this.limitFamily = r;
            }
        }

       
        GameObject pattern = TrashMan.spawn(gameWeights.levels[res].name);
        pattern.transform.position = new Vector3(0, -6, 0);
        Spawns spawns = pattern.GetComponent<Spawns>();

        FillEnemy(spawns, meters);
    }


    public void FillEnemy(Spawns _spawns, int meters)
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
    }

    public void ReportDie(Enemy enemy)
    {
        enemy.isDie = true;
        bool endHorda = true;

        for (int i = 0; i < cHorda.Count; i++)
        {
            endHorda = cHorda[i].isDie;
            if (!endHorda)
                break;
        }

        if (endHorda)
            Create(countHorda);
    }

    public int countHorda = 0;

    public void Remove(bool createOther)
    {
        
    }

   
}
