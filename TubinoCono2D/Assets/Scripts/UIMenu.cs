using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum AnimationState { StartAnimationTitle, EndAnimationTitle, StartAnimationButton, EndAnimationButton }

public class UIMenu : MonoBehaviour
{
    public RectTransform titleMenu;
    public RectTransform ButtonMenu;
    AnimationState state;

    void Start()
    {
        StartPosition();
        titleMenu.DOAnchorPosY(0f, 0.25f, true);
        state = AnimationState.StartAnimationTitle;
    }
    void Update()
    {
        switch(state)
        {
            case AnimationState.StartAnimationTitle:
                if (titleMenu.anchoredPosition.y == 0)
                {
                    titleMenu.DOShakeAnchorPos(0.25f, 25f, 75, 360);
                    state = AnimationState.EndAnimationTitle;
                }
            break;
            case AnimationState.EndAnimationTitle:
                ButtonMenu.DOAnchorPosY(0f, 0.25f, true);
                state = AnimationState.StartAnimationButton;
            break;
            case AnimationState.StartAnimationButton:
                if (ButtonMenu.anchoredPosition.y == 0)
                {
                    ButtonMenu.DOShakeAnchorPos(0.25f, 25f, 75, 360);
                    state = AnimationState.EndAnimationButton;
                }
            break;
        }
    }

    private void StartPosition()
    {
        titleMenu.anchoredPosition = new Vector2(0f, 650f);
        ButtonMenu.anchoredPosition = new Vector2(0f, -650f);
    }

    public void ChangeScene(string scene)
    {

    }
}
