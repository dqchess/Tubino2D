using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePopup : MonoBehaviour
{

    public void OnClickRestart() 
    {
        Close();
        ScreenMan.Me.GotoGame();
    }

    public void OnClickContinue()
    {
        Close();
    }

    public void OnClickHome()
    {
        Close();
        ScreenMan.Me.GoToMenu();
    }

    public void Open()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 0;

    }

    public void Close()
    {
        
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
