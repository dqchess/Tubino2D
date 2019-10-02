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
    private void OnMouseDown()
    {
        this.clife--;

        if (showParticles)
        {
            ParticleSystem cono = TrashMan.spawn("moneyPa", this.transform.position+Vector3.up*0.5f).GetComponent<ParticleSystem>();
            cono.Play();
        }
        
        /*if (this.crusheable.transform.position.x < 0)
        {
            Cono cono = TrashMan.spawn("cono_r", this.transform.position + Vector3.left * 0.8f + Vector3.up * crusheable.offsetY).GetComponent<Cono>();
            cono.Initialize();
        }
        else
        {
            Cono cono = TrashMan.spawn("cono_l", this.transform.position + Vector3.right * 0.8f + Vector3.up * crusheable.offsetY).GetComponent<Cono>();
            cono.Initialize();
        }*/


        if (this.clife <= 0)
        {
            this.GetComponent<IDie>().OnDie();
            this.crusheable.OnCrush();
        }

        
        
    }
}
