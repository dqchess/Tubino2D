using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush : MonoBehaviour
{
    private void OnMouseDown()
    {
        this.GetComponent<IDie>().OnDie();
    }
}
