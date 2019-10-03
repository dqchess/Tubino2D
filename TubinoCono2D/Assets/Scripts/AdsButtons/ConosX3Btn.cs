using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;


[RequireComponent(typeof(Button))]
public class ConosX3Btn : MonoBehaviour
{
    Button myButton;
    string myPlacementId = "ConosX3";
    UIMenu uiMainMenuScreen;
    

    public void Initialize(UIMenu _uiMainMenuScreen, OnFailCompleteVideo _onFail, OnSuccessCompleteVideo _onComplete)
    {
        this.uiMainMenuScreen = _uiMainMenuScreen;
        myButton = GetComponent<Button>();
        myButton.interactable = Advertisement.IsReady(myPlacementId);
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        AdsMan.Me.conosX3Event.SetListener(OnUnityAdsReady, _onFail, _onComplete);

    }

    void ShowRewardedVideo()
    {
        uiMainMenuScreen.OnClickConosX3();
        Advertisement.Show(myPlacementId);
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == myPlacementId)
        {
            myButton.interactable = true;
        }
    }

    public void RemoveListeners()
    {
        Debug.Log("removing listener conox3");
        if (myButton) myButton.onClick.RemoveAllListeners();
    }



}