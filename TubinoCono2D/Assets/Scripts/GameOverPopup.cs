using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPopup : MonoBehaviour
{
    public void OnClickRestart()
    {
        ScreenMan.Me.GotoGame();
    }

    public void OnClickHome()
    {
        ScreenMan.Me.GoToMenu();
    }

    public void Open()
    {
        this.gameObject.SetActive(true);
    }
}
