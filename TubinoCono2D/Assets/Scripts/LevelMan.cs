using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMan : MonoBehaviour
{
    public int level = 0;
    bool generating = false;
    public EnemyFactory enemyFactory;
    public GameWeights gw;
    private void Awake()
    {
        enemyFactory = new EnemyFactory(this, gw);
        enemyFactory.Initialize();
    }

    public void StartGeneration()
    {
        this.generating = true;
        enemyFactory.Create(0);
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
