using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum AnimationState { StartAnimationTitle, EndAnimationTitle, StartAnimationButton, EndAnimationButton, ExitAnimationMenu, ChangeScene }

public class UIMenu : MonoBehaviour
{
    public RectTransform menuParent;
    public RectTransform titleMenu;
    public RectTransform buttonMenu;
    public RectTransform optionsPanel;
    CanvasScaler canvasScaler;
    AnimationState state;
    bool exitMenu, methodSelection;
    public ConosX3Btn conosX3Btn;
    private void Start()
    {
        canvasScaler = GetComponent<CanvasScaler>();

        StartPosition();
        titleMenu.DOAnchorPosY(0f, 0.25f, true);
        state = AnimationState.StartAnimationTitle;

        exitMenu = false;

        conosX3Btn.Initialize(this, OnFailConoX3Video, OnCompleteConoX3Video);
    }

    public void OnFailConoX3Video()
    {
        conosX3Btn.GetComponent<Button>().interactable = true;
    }

    public void OnCompleteConoX3Video()
    {
        conosX3Btn.GetComponent<Button>().interactable = true;
        PowerupMan.Me.AddCono(3);
    }
    public void OnClickConosX3()
    {
        conosX3Btn.GetComponent<Button>().interactable = false;
    }

    private void Update()
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
            case AnimationState.EndAnimationButton:
                if (exitMenu)
                {
                    titleMenu.DOAnchorPosY(950f, 0.25f, true);
                    buttonMenu.DOAnchorPosY(-950f, 0.25f, true);
                    state = AnimationState.ExitAnimationMenu;
                }
            break;
            case AnimationState.ExitAnimationMenu:
                if (titleMenu.anchoredPosition.y == 950f)
                {
                    state = AnimationState.ChangeScene;
                }
            break;
            case AnimationState.ChangeScene:
                    conosX3Btn.RemoveListeners();
                    DOTween.KillAll();
                    SelectorMethod(methodSelection);
            break;
        }
    }

    public void ShowOptionPanel()
    {
        optionsPanel.DOAnchorPosX(0, 0.25f, true);
        menuParent.DOAnchorPosX(-canvasScaler.referenceResolution.x, 0.25f, true);
    }

    public void hiddenOptionPanel()
    {
        optionsPanel.DOAnchorPosX(canvasScaler.referenceResolution.x, 0.25f, true);
        menuParent.DOAnchorPosX(0, 0.25f, true);
    }

    private void StartPosition()
    {
        titleMenu.anchoredPosition = new Vector2(0f, 750f);
        buttonMenu.anchoredPosition = new Vector2(0f, -750f);
        optionsPanel.anchoredPosition = new Vector2(canvasScaler.referenceResolution.x, 0);
    }

    private void GoToLevelSelector()
    {
        ScreenMan.Me.GoToLevelSelector();
    }

    private void GoToCanaFronton()
    {
        ScreenMan.Me.GotoCanada();
    }

    public void ChangeScene(bool method)
    {
        exitMenu = true;
        methodSelection = method;
    }

    public void SelectorMethod(bool method)
    {
        if (method)
        {
            GoToLevelSelector();
        }
        else
        {
            GoToCanaFronton();
        }
    }
}