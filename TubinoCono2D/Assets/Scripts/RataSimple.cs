﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RataSimple : Enemy
{

    
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
}
