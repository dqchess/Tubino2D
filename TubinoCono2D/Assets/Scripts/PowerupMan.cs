using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupMan : MonoBehaviour
{
    public static PowerupMan Me;
    public int numConos = 3;
    private void Awake()
    {
        Me = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        
    }

    public void AddCono(int n)
    {
        numConos+=n;
        ES3.Save<int>("conos", numConos);
    }
    public bool SubstractCono()
    {
        if (numConos <= 0)
        {
            numConos = 0;
            return false;
        }
            
        numConos--;
        ES3.Save<int>("conos", numConos);

        return true;
    }

    private void Start()
    {
        this.numConos = ES3.Load<int>("conos", 3); 
    }
}
