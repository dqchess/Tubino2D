using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEnemy : MonoBehaviour, IDie
{
    public Enemy enemy;
    public void OnDie()
    {
        if (!enemy.isDie)
        {
            enemy.isDie = true;
            

            TrashMan.despawn(this.gameObject);
            Cono cono =  TrashMan.spawn("cono", this.transform.position).GetComponent<Cono>();
            cono.Initialize();
            Game.Me.OnEnemyDie(this.enemy);

        }
        

    }


    public void OnPass()
    {
        if (!enemy.isDie)
        {
            enemy.isDie = true;
            TrashMan.despawn(this.gameObject);
            Game.Me.ReportPass(enemy);

        }


    }


}
