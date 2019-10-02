using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieProtestante : MonoBehaviour, IDie
{
    public Protestante protestante;
    public void OnDie()
    {
        if (!protestante.isDie)
        {
            protestante.isDie = true;

            TrashMan.despawn(this.gameObject);

            Game.Me.OnGameOver();

        }
    }


    public void OnPass()
    {
        if (!protestante.isDie)
        {
            protestante.isDie = true;
            TrashMan.despawn(this.gameObject);
        }
    }
}
