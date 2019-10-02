using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rb;
    float speed = 5;
    bool moving = false;
    public void Initialize()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        moving = true; 
             
    }

    public void Traslating()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        moving = false;
    }




    void Update()
    {
        if (!moving)
            return;

        if (this.gameObject.transform.position.y > 6)
        {
            Kill();
        }

        

    }

    private void FixedUpdate()
    {
        if (!moving)
            return;

        //Debug.Log("no mueve");
        rb.velocity = new Vector3(0, speed, 0);
    }

    void Kill()
    {
        TrashMan.despawn(this.gameObject);
    }

   
        
            
        
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<DieEnemy>().OnDie();

            ParticleSystem cono = TrashMan.spawn("moneyPa", this.transform.position + Vector3.up * 0.5f).GetComponent<ParticleSystem>();
            cono.Play();
        }
        
    }

}
