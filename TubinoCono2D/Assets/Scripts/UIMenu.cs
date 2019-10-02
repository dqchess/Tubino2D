using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum AnimationState { StartAnimationTitle, EndAnimationTitle, StartAnimationButton, EndAnimationButton }

public class UIMenu : MonoBehaviour
{
    public RectTransform titleMenu;
    public RectTransform buttonMenu;
    public RectTransform optionsPanel;
    CanvasScaler canvasScaler;
    AnimationState state;

    void Start()
    {
        canvasScaler = GetComponent<CanvasScaler>();

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
                buttonMenu.DOAnchorPosY(0f, 0.25f, true);
                state = AnimationState.StartAnimationButton;
            break;
            case AnimationState.StartAnimationButton:
                if (buttonMenu.anchoredPosition.y == 0)
                {
                    buttonMenu.DOShakeAnchorPos(0.25f, 25f, 75, 360);
                    state = AnimationState.EndAnimationButton;
                }
            break;
        }
    }

    public void ShowOptionPanel()
    {
        optionsPanel.DOAnchorPosX(0, 0.25f, true);
    }

    public void hiddenOptionPanel()
    {
        optionsPanel.DOAnchorPosX(canvasScaler.referenceResolution.x, 0.25f, true);
    }

    private void StartPosition()
    {
        titleMenu.anchoredPosition = new Vector2(0f, 650f);
        buttonMenu.anchoredPosition = new Vector2(0f, -650f);
        optionsPanel.anchoredPosition = new Vector2(canvasScaler.referenceResolution.x, 0);
    }

    public void ChangeScene(string scene)
    {

    }

    public void GoToLevelSelector()
    {
        ScreenMan.Me.GoToLevelSelector();
    }
}
