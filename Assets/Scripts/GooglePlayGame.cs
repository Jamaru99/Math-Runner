 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using GooglePlayGames;
 using UnityEngine.SocialPlatforms;
 using GooglePlayGames.BasicApi;
 using System;

 public class GooglePlayGame : MonoBehaviour {

   public const string EasyLeaderboard = "CgkIpsf76oYXEAIQAQ";
   public const string MediumLeaderboard = "CgkIpsf76oYXEAIQAg";
   public const string HardLeaderboard = "CgkIpsf76oYXEAIQAw";

 	public static void Init(){
 		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build ();
 		PlayGamesPlatform.InitializeInstance (config);
 		PlayGamesPlatform.DebugLogEnabled = true;
 		PlayGamesPlatform.Activate ();
 	}

 	public static void Login(bool prompt, Action<SignInStatus> onLogin)
 	{

 		if (Social.Active == null)
 		{
 			return;
 		}

 		if (IsAuthenticated())
 		{
 			return;
 		}

		PlayGamesPlatform.Instance.Authenticate(prompt ? SignInInteractivity.CanPromptAlways : SignInInteractivity.NoPrompt, (result) => {
			onLogin(result);
		});
 	}

 	public static bool IsAuthenticated()
 	{
 		return Social.localUser.authenticated;
 	}

 	public static void IncrementAchievement(string achievement, int points, Action<bool> onIncrementAchievement)
 	{
 		PlayGamesPlatform.Instance.IncrementAchievement(achievement, points, (bool success) => {
      
 			if(onIncrementAchievement != null)
 			{
 				onIncrementAchievement(success);
 			}
      
 		});
 	}

 	public static void ReportAchievementProgress(string achievementID, float progress, Action<bool> onIncrementAchievement)
 	{
 		Social.ReportProgress(achievementID, progress, (bool success) => {

      if(onIncrementAchievement != null)
      {
        onIncrementAchievement(success);
      }

 		});
 	}

  public static void ReportScore(string id, long score)
  {
    Social.ReportScore(score, id, (bool success) => { });
  }

  public static void ShowLeaderboardsUI()
  {
    if(IsAuthenticated())
    {
      PlayGamesPlatform.Instance.ShowLeaderboardUI();
    }
    else
    {
      Login(true, (result) => {});
    }
  }
 }

