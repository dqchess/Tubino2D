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
    public UILevelSelector uILevelSelector;
    public void Initialize(int _idLevel, UILevelSelector _uILevelSelector)
    {
        this.uILevelSelector = _uILevelSelector;
        this.idLevel = _idLevel;

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
        this.uILevelSelector.GoToLevelSelector(true);
        // ScreenMan.Me.GotoGame();
    }
}
