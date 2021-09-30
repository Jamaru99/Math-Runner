using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static Mode mode;

  public static void ReloadLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public static void LoadEndlessGame()
  {
    SceneManager.LoadScene(1);
  }
}

public enum Mode
{
  EASY,
  MEDIUM,
  HARD
}
