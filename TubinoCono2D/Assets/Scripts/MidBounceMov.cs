using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBounceMov : MonoBehaviour
{
    public float speed = 5;
    public float speedX = 5;
    public int factor = 1;
    public bool d = false;
    public Rigidbody2D rb;

    public GameObject body;
    private void FixedUpdate()
    {
        this.rb.velocity = new Vector3(speedX*factor, speed, 0);

    }
    void Update()
    {

        if (d)
        {
            if (this.rb.position.x > -1f && factor == 1)
            {
                factor = -1;
                Vector3 s = this.transform.localScale;
                s.x = -1;
                this.body.transform.localScale = s;


            }
            else if (this.rb.position.x < -2f && factor == -1)
            {
                factor = 1;
                Vector3 s = this.transform.localScale;
                s.x = 1;
                this.body.transform.localScale = s;
            }
        }
        else
        {
            if (this.rb.position.x > 2f && factor == 1)
            {
                factor = -1;
                Vector3 s = this.transform.localScale;
                s.x = -1;
                this.body.transform.localScale = s;


            }
            else if (this.rb.position.x < 1 && factor == -1)
            {
                factor = 1;
                Vector3 s = this.transform.localScale;
                s.x = 1;
                this.body.transform.localScale = s;
            }
        }
        


    }
}
