using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static Mode mode;

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
