using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
  static UIManager instance;
  public static UIManager Instance { get { return instance; } set { instance = value; } }

  public TextMeshProUGUI highscoreEasyText;
  public TextMeshProUGUI highscoreMediumText;
  public TextMeshProUGUI highscoreHardText;

  public TextMeshProUGUI scoreText;
  public GameObject gameOverPanel;
  public GameObject gameOverPanelAds;

  public Image musicToggle;
  public Sprite musicOn;
  public Sprite musicOff;

  public void SetEasyHighscoreText(int highscore)
  {
    if (highscoreEasyText != null)
    {
      highscoreEasyText.text += highscore;
    }
  }

  public void SetMediumHighscoreText(int highscore)
  {
    if (highscoreMediumText != null)
    {
      highscoreMediumText.text += highscore;
    }
  }

  public void SetHardHighscoreText(int highscore)
  {
    if (highscoreHardText != null)
    {
      highscoreHardText.text += highscore;
    }
  }

  public void UpdateScoreUI(float score)
  {
    if(scoreText != null)
    {
      scoreText.text = score.ToString();
    }
  }

  public void ShowGameOver(bool secondChance)
  {
    if(secondChance)
    {
      gameOverPanelAds.SetActive(true);
    } 
    else
    {
      gameOverPanel.SetActive(true);
    }
  }

  public void Restart()
  {
    Player.score = 0;
    GameManager.LoadEndlessGame();
  }

  public void LoadMenu()
  {
    Player.score = 0;
    GameManager.LoadMenu();
  }

  public void PlayEasy()
  {
    GameManager.mode = Mode.EASY;
    GameManager.LoadEndlessGame();
  }

  public void PlayMedium()
  {
    GameManager.mode = Mode.MEDIUM;
    GameManager.LoadEndlessGame();
  }

  public void PlayHard()
  {
    GameManager.mode = Mode.HARD;
    GameManager.LoadEndlessGame();
  }

  public void SetToggleMuteInitialSprite()
  {
    if(musicToggle != null && !GameManager.GetHasMusic())
    {
      musicToggle.sprite = musicOff;
    }
  }

  public void ToggleMuteUI()
  {
    Music music = GameObject.Find("Music").GetComponent<Music>();
    if(musicToggle.sprite == musicOn)
    {
      musicToggle.sprite = musicOff;
      
    } else {
      musicToggle.sprite = musicOn;
    }
    music.ToggleMute();
  }

  public void WatchVideo()
  {
    AdManager.Instance.ShowRewardedAd();
  }
}
