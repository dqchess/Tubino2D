using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tombo : Enemy
{
    public GameObject casco;
    public GameObject escudo;

    public override void Initialize(int _parameter)
    {
        int spd = 3;
        if (_parameter == 0)
            spd = 3;
        else if (_parameter == 1)
            spd = 5;

        this.GetComponent<VerticalMov>().SetSpeed(spd);
        base.Initialize(_parameter);


    }


    public override void OnReciveHit(int lifes)
    {
        if (lifes == 2)
            casco.SetActive(false);

        if (lifes == 1)
            escudo.SetActive(false);
    }
}
