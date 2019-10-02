using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMan : MonoBehaviour
{
    public static WorldMan Me;
    public int currentLevel = 0;
    private void Awake()
    {
        Me = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public void SetCurrentLevel(int level)
    {
        this.currentLevel = level;
    }
}
