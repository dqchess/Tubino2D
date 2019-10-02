using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public bool isDie = false;
   public void Initialize()
   {
        this.isDie = false;
   }

    public void Die()
    {
        this.isDie = true;
    }


    private void Update()
    {
        if (this.isDie)
            return;

        if (this.transform.position.y > 2.18f)
        {
            //TrashMan.despawn(this.gameObject);
            this.GetComponent<DieEnemy>().OnPass();
            
        }
    }

}
