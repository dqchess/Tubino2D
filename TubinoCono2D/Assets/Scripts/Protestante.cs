using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protestante : ICrusheable
{
    
    public bool isDie = false;
    public void Initialize()
    {
        this.isDie = false;
        this.GetComponent<Crush>().Initialize(this);
    }


    public void Die()
    {
        this.isDie = true;
    }

    public override void OnCrush()
    {
        VibrateMan.Me.Vibrate();
        Game.Me.OnGameOver();
    }



    private void Update()
    {
        if (this.isDie)
            return;

        if (this.transform.position.y < -7.3f)
        {
            this.GetComponent<DieProtestante>().OnPass();

        }
    }

}
