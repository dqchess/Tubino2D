using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RataSimple : Enemy
{
    public List<Sprite> sprites;
    public SpriteRenderer head;

    public override void Initialize(int _parameter)
    {
        head.sprite = sprites[Random.Range(0,sprites.Count)];
        int spd = 3;
        if (_parameter == 0)
            spd = 3;
        else if (_parameter == 1)
            spd = 5;

        this.GetComponent<VerticalMov>().SetSpeed(spd);
        base.Initialize(_parameter);

    }
}
