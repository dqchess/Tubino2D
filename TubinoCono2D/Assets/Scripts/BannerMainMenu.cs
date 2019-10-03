using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerMainMenu : MonoBehaviour
{
    public string placementId = "bannerPlacement";

    void Start()
    {
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!AdsMan.Me.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        AdsMan.Me.ShowBanner(placementId);


    }

    
}
