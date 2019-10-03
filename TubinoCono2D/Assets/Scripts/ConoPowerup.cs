using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConoPowerup : MonoBehaviour
{
    //int numConos = 0;
    public Camera cam;
    public Text counterTxt;
    private void Awake()
    {
        //numConos = PowerupMan.Me.numConos;
        counterTxt.text = "" + PowerupMan.Me.numConos;
    }

    Bullet cono;
    bool waiting = false;



    public List<Vector3> spa = new List<Vector3> {

        new Vector3(0, 0, 0),
        new Vector3(1, 0, 0),
        new Vector3(2, 0, 0),
        new Vector3(3, 0, 0),
        new Vector3(4, 0, 0),

    };

    public void OnClick()
    {
        if (PowerupMan.Me.SubstractCono())
        {
            Vector3 ini = new Vector3(-2, -6, 0);

            for (int i = 0; i < spa.Count; i++)
            {
                Bullet b = TrashMan.spawn("cono", ini + spa[i]).GetComponent<Bullet>();
                b.Initialize();
            }
        }
       

        

        counterTxt.text = "" + PowerupMan.Me.numConos;
    }
   
}
