using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateMan : MonoBehaviour
{
    public static VibrateMan Me;
    private void Awake()
    {
        Me = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    public void Vibrate()
    {
        if (vibrating)
            return;

        vibrating = true;
    }

    bool vibrating = false;
    float c = 0;
    float tc = 0.15f;

    private void Update()
    {
        if (!vibrating)
            return;

        Handheld.Vibrate();

        this.c += Time.deltaTime;
        if (this.c > this.tc)
        {
            this.c = 0;
            this.vibrating = false;
        }
    }
}
