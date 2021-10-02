using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
  static bool hasInstance = false;
  AudioSource audioSource;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
    if (hasInstance)
    {
      Destroy(gameObject);
    }
    else
    {
      hasInstance = true;
      DontDestroyOnLoad(gameObject);
      audioSource.mute = !GameManager.GetHasMusic();
    }
  }

  public void ToggleMute()
  {
    audioSource.mute = !audioSource.mute;
    GameManager.SetHasMusic(!audioSource.mute);
  }

}
