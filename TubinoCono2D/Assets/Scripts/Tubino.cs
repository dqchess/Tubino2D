using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubino : Enemy
{
    public GameObject cono;

    public override void Initialize(int _parameter)
    {
        this.GetComponent<VerticalMov>().SetSpeed(3);
        base.Initialize(_parameter);


    }


    public override void OnReciveHit(int lifes)
    {
        if (lifes == 5)
            cono.SetActive(false);
    }
}
