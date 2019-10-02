using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boom : MonoBehaviour
{

    public List<Sprite> sprites;
    public SpriteRenderer sr;
    /*float c;
    float t = 0.2f;
    bool waiting = false;*/
    public void Initialize()
    {
        //this.c = 0;
        //this.waiting = true;
        this.sr.sprite = sprites[Random.Range(0, sprites.Count)];
        sr.transform.DOScale(.7f, 0.1f).SetEase(Ease.InOutSine).SetLoops(2, LoopType.Yoyo).OnComplete(OnComplete);

    }

    public void OnComplete()
    {
        TrashMan.despawn(this.gameObject);
    }
    /*void Update()
    {
        if (!this.waiting)
            return;

        this.c += Time.deltaTime;
        if (c > t)
        {
            TrashMan.despawn(this.gameObject);
            this.waiting = false;
        }
    }*/

}
