using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsMan : MonoBehaviour
{
    public static AdsMan Me;
#if UNITY_IOS
        private string gameId = "3312904";
#elif UNITY_ANDROID
    private string gameId = "3312904";
#else
        private string gameId = "3312904";
#endif
    bool testMode = true;
        
    public ConosX3Event conosX3Event;

    private void Awake()
    {
        Me = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        Advertisement.Initialize(gameId, testMode);

        conosX3Event = new ConosX3Event();
        Advertisement.AddListener(conosX3Event);

    }

    public bool IsAvailable()
    {
        return Advertisement.IsReady(gameId);
    }

    public bool IsReady(string placement)
    {
        return Advertisement.IsReady(placement);

    }

    public void ShowBanner(string placementId)
    {
        Advertisement.Banner.Show(placementId);        
    }

    public void DestroyBanner()
    {
        Advertisement.Banner.Hide();
    }
}
