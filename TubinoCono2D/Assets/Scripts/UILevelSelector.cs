using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UILevelSelector : MonoBehaviour
{
    public void OnClick(int level)
    {
        WorldMan.Me.SetCurrentLevel(level);
        ScreenMan.Me.GotoGame();
    }
}
