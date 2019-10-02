using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameWeights", menuName = "Congreso/GameWeights", order = 1)]
public class GameWeights : ScriptableObject
{
    public List<LootValue> levels;
    public List<LootValue> enemy;

}
