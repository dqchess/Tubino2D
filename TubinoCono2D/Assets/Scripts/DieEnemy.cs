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


            /*MoneyFly moneyfly = TrashMan.spawn("moneyFly", Game.Me.ui.mycamera.WorldToScreenPoint(this.transform.position)).GetComponent<MoneyFly>();
            moneyfly.gameObject.transform.SetParent(Game.Me.ui.canvas.transform);
            moneyfly.Fly();*/

            TrashMan.despawn(this.gameObject);
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
