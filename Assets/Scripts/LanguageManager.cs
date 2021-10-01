using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageManager : MonoBehaviour
{
  static LanguageManager instance;
  public static LanguageManager Instance { get { return instance; } set { instance = value; } }

  public TextMeshProUGUI highscoreEasyText;
  public TextMeshProUGUI highscoreMediumText;
  public TextMeshProUGUI highscoreHardText;

  public TextMeshProUGUI buttonEasyText;
  public TextMeshProUGUI buttonMediumText;
  public TextMeshProUGUI buttonHardText;

  public TextMeshProUGUI gameOverTitle;
  public TextMeshProUGUI gameOverRestart;

  public void TranslateToPortuguese()
  {
    bool isPortuguese = Application.systemLanguage == SystemLanguage.Portuguese;

    if (isPortuguese)
    {
      if (highscoreEasyText != null)
      {
        highscoreEasyText.text = "Recorde: ";
      }
      if (highscoreMediumText != null)
      {
        highscoreMediumText.text = "Recorde: ";
      }
      if (highscoreHardText != null)
      {
        highscoreHardText.text = "Recorde: ";
      }

      if (buttonEasyText != null)
      {
        buttonEasyText.text = "FÁCIL";
      }
      if (buttonMediumText != null)
      {
        buttonMediumText.text = "MÉDIO";
      }
      if (buttonHardText != null)
      {
        buttonHardText.text = "DIFÍCIL";
      }

      if (gameOverTitle != null)
      {
        gameOverTitle.text = "Já era :(";
      }
      if (gameOverRestart != null)
      {
        gameOverRestart.text = "RECOMEÇAR";
      }
    }
  }
}
