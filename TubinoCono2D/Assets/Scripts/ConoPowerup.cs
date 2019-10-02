using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConoPowerup : MonoBehaviour
{
    int numConos = 0;
    public Camera cam;
    private void Awake()
    {
        numConos = ES3.Load<int>("conos", 3);

    }

    Bullet cono;
    bool waiting = false;

  
    public void OnClick()
    {
        if (numConos > 0)
        {
            Debug.Log("pressing");            
            cono = TrashMan.spawn("cono").GetComponent<Bullet>();
            cono.Traslating();
            waiting = true;
            //StartCoroutine(Wa());
            c = 0;
        }

        numConos--;
    }

    int c = 0;
    
    private void Update()
    {
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
    }
}
