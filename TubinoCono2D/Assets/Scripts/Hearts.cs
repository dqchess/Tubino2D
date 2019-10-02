using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    public Text text;
    public List<GameObject> hearts;
    public void UpdateLives(int lives)
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].SetActive(i < lives);
        }
        //text.text = "" + lives;
    }

}
