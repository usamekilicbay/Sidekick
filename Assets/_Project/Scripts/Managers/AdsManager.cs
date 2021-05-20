using Constants;
using GameType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : EventProvider, IUnityAdsListener
{
#if UNITY_ANDROID
    private string gameId = "4130677";
#elif UNITY_IOS
    private string gameId= "4130676";
#endif

    private bool testMode = true;

    protected override void Awake()
    {
        base.Awake();
        Advertisement.Initialize(gameId, testMode);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    #region EVENT
    protected override void Subscribe()
    {
        EventManager.Instance.ShowRewardedAd += ShowRewardedAd;
        Advertisement.AddListener(this);
    }

    protected override void Unsubscribe()
    {
        EventManager.Instance.ShowRewardedAd -= ShowRewardedAd;
        Advertisement.RemoveListener(this);
    }
    #endregion

    #region INTERSTITIAL AD
    private void ShowInterstitialAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(AdPlacement.INTERSTITIAL))
        {
            // Replace mySurfacingId with the ID of the placements you wish to display as shown in your Unity Dashboard.
            Advertisement.Show(AdPlacement.INTERSTITIAL);
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }
    #endregion

    #region REWARDED AD
    private void ShowRewardedAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(AdPlacement.REWARDED))
        {
            Advertisement.Show(AdPlacement.REWARDED);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            GameManager.GameState = GameState.GAME;
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
            GameManager.GameState = GameState.FAILED;
        }
        else if (showResult == ShowResult.Failed)
        {
            GameManager.GameState = GameState.FAILED;
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == AdPlacement.REWARDED)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
    #endregion
}
