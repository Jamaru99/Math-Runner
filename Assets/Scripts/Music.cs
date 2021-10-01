using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
  static bool hasInstance = false;
  AudioSource audioSource;

  void Start()
  {
    if (hasInstance)
    {
      Destroy(gameObject);
    }
    else
    {
      hasInstance = true;
      DontDestroyOnLoad(gameObject);
    }
  }


}
