using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICrusheable : MonoBehaviour
{
    public float offsetY;

    public abstract void OnCrush();
}
