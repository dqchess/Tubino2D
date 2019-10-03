using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush : MonoBehaviour
{
    public int life = 1;
    int  clife = 0;
    ICrusheable crusheable;
    public bool showParticles = true;

    public void Initialize(ICrusheable _crusheable)
    {
        this.crusheable = _crusheable;
        clife = life;
    }

    public void OnCrush()
    {
        this.clife--;

        if (showParticles)
        {
            ParticleSystem cono = TrashMan.spawn("moneyPa", this.transform.position + Vector3.up * 0.5f).GetComponent<ParticleSystem>();
            cono.Play();

            TrashMan.spawn("TMR", this.transform.position).GetComponent<Boom>().Initialize();
        }

        if (this.clife <= 0)
        {
            this.GetComponent<IDie>().OnDie();
            this.crusheable.OnCrush();
        }

        this.crusheable.OnReciveHit(this.clife);
    }


    /*private void OnMouseDown()
    {
        this.clife--;

        if (showParticles)
        {
            ParticleSystem cono = TrashMan.spawn("moneyPa", this.transform.position+Vector3.up*0.5f).GetComponent<ParticleSystem>();
            cono.Play();

            TrashMan.spawn("TMR", this.transform.position).GetComponent<Boom>().Initialize();
        }      

        if (this.clife <= 0)
        {
            this.GetComponent<IDie>().OnDie();
            this.crusheable.OnCrush();
        }

        this.crusheable.OnReciveHit(this.clife);
    }*/
}
