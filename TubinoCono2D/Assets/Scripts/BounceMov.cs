using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceMov : MonoBehaviour
{
    public float speed = -5;
    public float speedX = -5;
    public int factor = 1;
    void Update()
    {
        this.transform.position += Vector3.up * speed * Time.deltaTime;
        this.transform.position += Vector3.right * factor * speedX * Time.deltaTime;

        if(this.transform.position.x > 2f && factor == 1)
        {
            factor = -1;
            Vector3 s = this.transform.localScale;
            s.x = -1;
            this.transform.localScale = s;
        }else if (this.transform.position.x < -2f && factor == -1)
        {
            factor = 1;
            Vector3 s = this.transform.localScale;
            s.x = 1;
            this.transform.localScale = s;
        }


    }
}
