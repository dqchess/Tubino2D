using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConoPowerup : MonoBehaviour
{
    int numConos = 0;
    public Camera cam;
    public Text counterTxt;
    private void Awake()
    {
        numConos = ES3.Load<int>("conos", 3);
        counterTxt.text = "" + numConos;
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
        numConos--;

        if (numConos > 0)
        {
            Vector3 ini = new Vector3(-2, -6, 0);

            for (int i = 0; i < spa.Count; i++)
            {
                Bullet b = TrashMan.spawn("cono", ini + spa[i]).GetComponent<Bullet>();
                b.Initialize();
            }
            

        }
        else
        {
            numConos = 0;
        }

        ES3.Save<int>("conos", numConos);

        counterTxt.text = "" + numConos;

        /*if (numConos > 0)
        {
            Debug.Log("pressing");            
            cono = TrashMan.spawn("cono").GetComponent<Bullet>();
            cono.Traslating();
            waiting = true;
            //StartCoroutine(Wa());
            c = 0;
        }

        */
    }

    int c = 0;
    
    //private void Update()
    //{
        /*if (waiting)
        {
            Vector3 s = cam.ScreenToWorldPoint(Input.mousePosition);
            s.z = 0;
            cono.transform.position = s;

            if (Input.GetMouseButtonUp(0))
            {
                if (c == 1)
                {
                    cono.Initialize();
                    waiting = false;
                }
                c++;
                
            }
        }*/
    //}
}
