using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
  static UIManager instance;
  public static UIManager Instance { get { return instance; } }

  public TextMeshProUGUI scoreText;

  void Start()
  {
    if (instance == null)
    {
      instance = this;
    }
  }

  public void UpdateScoreUI(float score)
  {
    scoreText.text = score.ToString();
  }

  public void ButtonPlayClick()
  {
    GameManager.LoadEndlessGame();
  }
}
