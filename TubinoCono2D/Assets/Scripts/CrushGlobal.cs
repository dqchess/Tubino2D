using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushGlobal : MonoBehaviour
{

    public LayerMask layermask;
    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((t.position)), Vector2.zero, 0.5f, layermask);
                if (hit.collider != null)
                {
                    Debug.Log("Touched it");
                    hit.collider.gameObject.GetComponent<Crush>().OnCrush();
                }
            }            
            ++i;
        }

        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero, 0.5f, layermask);
                if (hit.collider != null)
                {
                    Debug.Log("Touched it");
                    hit.collider.gameObject.GetComponent<Crush>().OnCrush();
                }
            }

           
        }*/
    }
}
