using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush : MonoBehaviour
{
    public int life = 1;
    int  clife = 0;
    Enemy enemy;

    public void Initialize(Enemy _enemy)
    {
        this.enemy = _enemy;
        clife = life;
    }
    private void OnMouseDown()
    {
        this.clife--;

        if (this.clife <= 0)
        {
            this.GetComponent<IDie>().OnDie();
        }

        
        
    }
}
