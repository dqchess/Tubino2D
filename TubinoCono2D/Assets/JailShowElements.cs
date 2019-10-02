using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JailShowElements : MonoBehaviour
{
    public Image headSprite;
    public Text nameObj;
    public Text EnemyCount;
    public Sprite[] headCollections;
    public Vector2[] offset;
    public string[] NameCollections;
    private int countElement = 0;

    private void Awake()
    {
        RenderSpriteAndName(countElement);
    }

    public void RenderSpriteAndName(int _index)
    {
        headSprite.sprite = headCollections[_index];
        headSprite.rectTransform.anchoredPosition = offset[_index];
        EnemyCount.text = ((_index + 1) +"/" +headCollections.Length);
        //nameObj.text = NameCollections[_index];
    }

    public void NextHead()
    {
        countElement++;

        if (countElement > headCollections.Length - 1)
        {
            countElement = 0;
        }

        RenderSpriteAndName(countElement);
    }

    public void PrevHead()
    {
        countElement--;

        if (countElement < 0)
        {
            countElement = headCollections.Length - 1;
        }

        RenderSpriteAndName(countElement);
    }
}
