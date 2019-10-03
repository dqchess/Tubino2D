using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protestante : ICrusheable
{
    int parameter = 0;
    public bool isDie = false;

    public virtual void Initialize(int _parameter)
    {
        this.parameter = _parameter;

        int spd = 3;
        if (_parameter == 0)
            spd = 3;
        else if (_parameter == 1)
            spd = 5;

        this.GetComponent<VerticalMov>().SetSpeed(spd);

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
