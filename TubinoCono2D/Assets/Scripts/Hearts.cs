using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    public Text text;

    public void UpdateLives(int lives)
    {
        text.text = "" + lives;
    }

}
