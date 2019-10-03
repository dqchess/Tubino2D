using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JailMenu : MonoBehaviour
{
    public RectTransform titleJail;
    public RectTransform buttonReturn;
    public RectTransform JailParent;
    public RectTransform buttonGroup;
    AnimationState state;
    bool exitLevel;
    private void Start()
    {
        StartPosition();

        state = AnimationState.StartAnimationTitle;

        exitLevel = false;
    }

    // Update is called once per frame
    private void Update()
    {
        switch(state)
        {
            case AnimationState.StartAnimationTitle:
                titleJail.DOAnchorPosY(-268f, 0.25f, true);
                JailParent.DOAnchorPosX(0f, 0.25f, true);
                buttonGroup.DOAnchorPosY(150f, 0.25f, true);
                state = AnimationState.EndAnimationTitle;
            break;
            case AnimationState.EndAnimationTitle:
                if (titleJail.anchoredPosition.y == -268f)
                {
                    titleJail.DOShakeAnchorPos(0.25f, 25f, 75, 360);
                    JailParent.DOShakeAnchorPos(0.25f, 25f, 75, 360);
                    buttonGroup.DOShakeAnchorPos(0.25f, 25f, 75, 360);
                    buttonReturn.DOAnchorPosX(-200f, 0.25f, true);
                    state = AnimationState.StartAnimationButton;
                }
            break;
            case AnimationState.StartAnimationButton:
                if (buttonReturn.anchoredPosition.x == -200f)
                {
                    buttonReturn.DOShakeAnchorPos(0.25f, 25f, 75, 360);
                    state = AnimationState.EndAnimationButton;
                }
            break;
            case AnimationState.EndAnimationButton:
                if (exitLevel)
                {
                    buttonReturn.DOAnchorPosY(150f, 0.15f, true);
                    titleJail.DOAnchorPosY(200f, 0.25f, true);
                    JailParent.DOAnchorPosX(800f, 0.25f, true);
                    buttonGroup.DOAnchorPosY(-150f, 0.25f, true);
                    state = AnimationState.ExitAnimationMenu;
                }
            break;
            case AnimationState.ExitAnimationMenu:
                if (titleJail.anchoredPosition.y == 200f)
                {
                    state = AnimationState.ChangeScene;
                }
            break;
            case AnimationState.ChangeScene:
                DOTween.KillAll();
                GoToMenu();
            break;
        }
    }

    private void StartPosition()
    {
        titleJail.anchoredPosition = new Vector2(0f,200f);
        buttonReturn.anchoredPosition = new Vector2(200f,-150f);
        JailParent.anchoredPosition = new Vector2(-800f,0);
        buttonGroup.anchoredPosition = new Vector2(0f,-150f);
    }

    private void GoToMenu()
    {
        ScreenMan.Me.GoToMenu();
    }

    public void ChangeScene()
    {
        exitLevel = true;
    }
}
