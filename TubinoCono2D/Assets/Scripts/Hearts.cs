using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public List<GameObject> hearts;

    public void UpdateLives(int lives)
    {
        for (int h = 0; h < hearts.Count; h++)
        {
            if(h<lives)
                hearts[h].SetActive(true);
            else
                hearts[h].SetActive(false);
        }
    }

}
