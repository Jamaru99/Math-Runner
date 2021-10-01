using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static Mode mode;

  const string EasyHighscoreKey = "EasyHighscore";
  const string MediumHighscoreKey = "MediumHighscore";
  const string HardHighscoreKey = "HardHighscore";

  void Start()
  {
    UIManager.Instance = GetComponent<UIManager>();
    UIManager.Instance.SetEasyHighscoreText(GetHighscore(EasyHighscoreKey));
    UIManager.Instance.SetMediumHighscoreText(GetHighscore(MediumHighscoreKey));
    UIManager.Instance.SetHardHighscoreText(GetHighscore(HardHighscoreKey));
  }

  int GetHighscore(string key)
  {
    return PlayerPrefs.GetInt(key, 0);
  }

  public static void SetHighscore(int score)
  {
    int highscore;
    switch (mode)
    {
      case Mode.EASY:
        highscore = PlayerPrefs.GetInt(EasyHighscoreKey, 0);
        if (score > highscore)
        {
          PlayerPrefs.SetInt(EasyHighscoreKey, score);
        }
        break;
      case Mode.MEDIUM:
        highscore = PlayerPrefs.GetInt(MediumHighscoreKey, 0);
        if (score > highscore)
        {
          PlayerPrefs.SetInt(MediumHighscoreKey, score);
        }
        break;
      case Mode.HARD:
        highscore = PlayerPrefs.GetInt(HardHighscoreKey, 0);
        if (score > highscore)
        {
          PlayerPrefs.SetInt(HardHighscoreKey, score);
        }
        break;
    }
  }

  public static void LoadEndlessGame()
  {
    SceneManager.LoadScene(1);
  }

  public static void LoadMenu()
  {
    SceneManager.LoadScene(0);
  }
}

public enum Mode
{
  EASY,
  MEDIUM,
  HARD
}
