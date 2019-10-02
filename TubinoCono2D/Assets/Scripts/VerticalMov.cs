using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMov : MonoBehaviour
{
    public float speed = -5;
    void Update()
    {
        this.transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
