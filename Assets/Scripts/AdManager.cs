using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;

public class AdManager : MonoBehaviour
{
  private static AdManager instance;
  public static AdManager Instance { get { return instance; } }

  RewardedAd rewardedAd;
  BannerView bannerView;
  string bannerId = "ca-app-pub-3940256099942544/6300978111";
  //ca-app-pub-1541045839364233/2005796445
  string videoId = "ca-app-pub-3940256099942544/5224354917";

  void Start()
  {
    instance = this;
    MobileAds.Initialize(initStatus => { });
    RequestRewardedAd();
  }

  public void HandleAdClosed(object sender, EventArgs args)
  {
    RequestRewardedAd();
  }

  public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
  {
    RequestRewardedAd();
  }

  public void HandleUserEarnedReward(object sender, Reward args)
  {
    GameManager.LoadEndlessGame();
    Player.secondChance = false;
    RequestRewardedAd();
  }

  void RequestRewardedAd()
  {
    rewardedAd = new RewardedAd(videoId);

    rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
    rewardedAd.OnAdClosed += HandleAdClosed;
    rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;

    AdRequest request = new AdRequest.Builder().Build();
    rewardedAd.LoadAd(request);
  }

  public void ShowRewardedAd()
  {
    if (rewardedAd.IsLoaded())
    {
      rewardedAd.Show();
    }
  }

  void RequestBanner()
  {
    bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);
    AdRequest request = new AdRequest.Builder().Build();
    bannerView.LoadAd(request);
  }

  public void ShowBanner()
  {
    bannerView.Show();
  }

  public void HideBanner()
  {
    bannerView.Hide();
  }
}