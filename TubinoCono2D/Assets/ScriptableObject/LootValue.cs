using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LootValue
{
    public string editorName;
    public string name;
    public int weight;
    public int parameter;
    public Vector2Int family;
    public Vector2Int range;


    public LootValue(string _name, int _w, Vector2Int _range, int _parameter, Vector2Int _family)
    {
        this.name = _name;
        this.weight = _w;
        this.range = _range;
        this.parameter = _parameter;
        this.family = _family;
    }
}