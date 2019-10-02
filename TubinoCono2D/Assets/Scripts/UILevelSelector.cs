using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UILevelSelector : MonoBehaviour
{
    public GameObject prefabItem;
    public RectTransform titleLevelSelection;
    public RectTransform container;
    public RectTransform returnButton;
    AnimationState state;
    bool exitLevel, methodSelection;

    private void Start()
    {
        for (int i = 0; i < Constants.numLevel; i++)
        {
            ItemLevelSelector item = GameObject.Instantiate(prefabItem).GetComponent<ItemLevelSelector>();
            item.gameObject.transform.SetParent(container, false);
            item.Initialize(i, this);
        }

        StartPosition();

        state = AnimationState.StartAnimationTitle;

        exitLevel = false;
    }
    public void OnClick(int level)
    {
       
    }

    private void Update()
    {
        switch (state)
        {
            case AnimationState.StartAnimationTitle:
                titleLevelSelection.DOAnchorPosY(-125f, 0.25f, true);
                container.DOAnchorPosY(-695f, 0.25f, true);
                state = AnimationState.EndAnimationTitle;
            break;
            case AnimationState.EndAnimationTitle:
                if (titleLevelSelection.anchoredPosition.y == -125f)
                {
                    titleLevelSelection.DOShakeAnchorPos(0.25f, 25f, 75, 360);
                    container.DOShakeAnchorPos(0.25f, 25f, 75, 360);
                    returnButton.DOAnchorPosX(-200f, 0.25f, true);
                    state = AnimationState.StartAnimationButton;
                }
            break;
            case AnimationState.StartAnimationButton:
                if (returnButton.anchoredPosition.x == -200f)
                {
                    returnButton.DOShakeAnchorPos(0.25f, 25f, 75, 360);
                    state = AnimationState.EndAnimationButton;
                }
            break;
            case AnimationState.EndAnimationButton:
                if (exitLevel)
                {
                    returnButton.DOAnchorPosY(-100f, 0.15f, true);
                    titleLevelSelection.DOAnchorPosY(750f, 0.25f, true);
                    container.DOAnchorPosY(-1800f, 0.25f, true);
                    state = AnimationState.ExitAnimationMenu;
                }
            break;
            case AnimationState.ExitAnimationMenu:
                if (titleLevelSelection.anchoredPosition.y == 750f)
                {
                    state = AnimationState.ChangeScene;
                }
            break;
            case AnimationState.ChangeScene:
                DOTween.KillAll();
                SelectorMethod(methodSelection);
            break;
        }
    }

    private void StartPosition()
    {
        titleLevelSelection.anchoredPosition = new Vector2(0f, 750f);
        container.anchoredPosition = new Vector2(0f, -1800f);
        returnButton.anchoredPosition = new Vector2(200f, 150f);
    }

    public void GoToLevelSelector(bool method)
    {
        exitLevel = true;
        methodSelection = method;
    }

    public void SelectorMethod(bool method)
    {
        if (method)
        {
            Gotogame();
        }
        else
        {
            GoToMenu();
        }
    }

    private void Gotogame()
    {
        ScreenMan.Me.GotoGame();
    }

    private void GoToMenu()
    {
        ScreenMan.Me.GoToMenu();
    }
}
