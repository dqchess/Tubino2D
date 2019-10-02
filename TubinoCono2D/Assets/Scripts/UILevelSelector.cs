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
    AnimationState state;

    private void Start()
    {
        for (int i = 0; i < Constants.numLevel; i++)
        {
            ItemLevelSelector item = GameObject.Instantiate(prefabItem).GetComponent<ItemLevelSelector>();
            item.gameObject.transform.SetParent(container, false);
            item.Initialize(i);
        }

        StartPosition();

        state = AnimationState.StartAnimationTitle;
    }
    public void OnClick(int level)
    {
       
    }

    private void Update()
    {
        switch (state)
        {
            case AnimationState.StartAnimationTitle:
                titleLevelSelection.DOAnchorPosY(-125, 0.25f, true);
                container.DOAnchorPosY(-695, 0.25f, true);
                state = AnimationState.EndAnimationTitle;
            break;
            case AnimationState.EndAnimationTitle:
            break;
        }
    }

    private void StartPosition()
    {
        titleLevelSelection.anchoredPosition = new Vector2(0f, 750f);
        container.anchoredPosition = new Vector2(0f, -1800f);
    }


}
