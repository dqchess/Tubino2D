using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RataMidDiagonal : Enemy
{
    public List<Sprite> spritesHead;
    public List<Sprite> spritesBody;
    public List<Sprite> spritesArms;
    public SpriteRenderer head;
    public SpriteRenderer body;
    public SpriteRenderer arm1;
    public SpriteRenderer arm2;
    public MidBounceMov midBounce;

    public override void Initialize(int _parameter)
    {
        if (_parameter == 0)
        {
            midBounce.d = true;
                 
        }
        else
        {
            midBounce.d = false;
        }

        head.sprite = spritesHead[Random.Range(0, spritesHead.Count)];
        int r = Random.Range(0, spritesBody.Count);
        body.sprite = spritesBody[r];
        arm1.sprite = spritesArms[r];
        arm2.sprite = spritesArms[r];

        /*int spd = 3;
        if (_parameter == 0)
            spd = 3;
        else if (_parameter == 1)
            spd = 5;*/

        //this.GetComponent<VerticalMov>().SetSpeed(5);
        base.Initialize(_parameter);

    }
}
