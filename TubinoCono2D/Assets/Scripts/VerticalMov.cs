using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMov : MonoBehaviour
{
    public float speed = 5;


    public Rigidbody2D rb;
    public void SetSpeed(float _speed)
    {
        speed = _speed;

    }

    /*void Update()
    {
        this.transform.position += Vector3.up * speed * Time.deltaTime;
    }*/

    private void FixedUpdate()
    {
        this.rb.velocity = Vector3.down*speed;
    }
}
