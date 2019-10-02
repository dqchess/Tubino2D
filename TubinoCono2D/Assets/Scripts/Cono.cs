using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cono : MonoBehaviour
{
    float c;
    float t = 0.2f;
    bool waiting = false;
    public void Initialize()
    {
        this.c = 0;
        this.waiting = true;
    }
    void Update()
    {
        if (!this.waiting)
            return;

        this.c += Time.deltaTime;
        if(c>t)
        {
            TrashMan.despawn(this.gameObject);
            this.waiting = false;
        }
    }
}
