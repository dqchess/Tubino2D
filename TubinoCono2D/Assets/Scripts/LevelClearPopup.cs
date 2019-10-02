using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClearPopup : MonoBehaviour
{
    public void OnClickRestart()
    {
        ScreenMan.Me.GotoGame();
    }

    public void OnClickNextLevel()
    {
        ScreenMan.Me.GoToLevelSelector();
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
