using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADHandler : MonoBehaviour {

	public void GetMagentByViewingAd()
    {
#if UNITY_ADS
        if (!Advertisement.isShowing)
        {
            Advertisement.Show();
        }
#endif
    }

    public void ShowDefaultAd()
    {
#if UNITY_ADS
        if (!Advertisement.IsReady())
        {
            Debug.Log("Ads not ready for default zone");
            return;
        }

        Advertisement.Show();
#endif
    }

    public void ShowRewardedAd()
    {
        const string RewardedZoneId = "rewardedVideo";

#if UNITY_ADS
        if (!Advertisement.IsReady(RewardedZoneId))
        {
            Debug.Log(string.Format("Ads not ready for zone '{0}'", RewardedZoneId));
            return;
        }

        var options = new ShowOptions { resultCallback = ResultCallback };
        Advertisement.Show(RewardedZoneId, options);
#endif
    }
#if UNITY_ADS
    private void ResultCallback(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                
                 //YOUR CODE TO REWARD THE GAMER
                 //Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
#endif
}