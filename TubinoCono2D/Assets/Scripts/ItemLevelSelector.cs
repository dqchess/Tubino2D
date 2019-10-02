using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLevelSelector : MonoBehaviour
{
    public Sprite star;
    public Sprite noStar;
    public List<Image> stars;
    public Text lvl;
    public Button button;
    int idLevel;
    public void Initialize(int idLevel)
    {
        lvl.text = "" + (idLevel + 1);

        if(!WorldMan.Me.leveldata[idLevel].isLock)
            button.onClick.AddListener(OnClick);        


        for (int i = 0; i < stars.Count; i++)
        {
            if (i < WorldMan.Me.leveldata[idLevel].stars)
            {
                stars[i].sprite = star;
            }
            else
            {
                stars[i].sprite = noStar;
            }
        }
    }

    public void OnClick()
    {
        WorldMan.Me.SetCurrentLevel(idLevel+1);
        ScreenMan.Me.GotoGame();
    }
}
