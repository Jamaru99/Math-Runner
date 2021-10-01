using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  static AudioManager instance;
  public static AudioManager Instance { get { return instance; } }

  public AudioClip jump;
  public AudioClip death;

  AudioSource audioSourceSoundEffects;
  AudioSource audioSourceMusic;

  void Start()
  {
    GameObject music = GameObject.Find("Music");
    if (instance == null)
    {
      instance = this;
      DontDestroyOnLoad(music);
    }
    else
    {
      Destroy(music);
    }
    audioSourceSoundEffects = GameObject.Find("SoundEffects").GetComponent<AudioSource>();
    audioSourceMusic = GameObject.Find("Music").GetComponent<AudioSource>();
  }

  public void PlayJump()
  {
    audioSourceSoundEffects.clip = jump;
    audioSourceSoundEffects.Play();
  }

  public void PlayDeath()
  {
    audioSourceSoundEffects.clip = death;
    audioSourceSoundEffects.Play();
  }
}
