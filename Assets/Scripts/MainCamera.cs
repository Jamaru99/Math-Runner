using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
  public Transform player;
  public float minY, maxY;

  void FixedUpdate()
  {
    if (player != null)
    {
      transform.position = new Vector3(player.position.x + 7, Mathf.Clamp(player.position.y, minY, maxY), -10);
      if (transform.position.x < 0)
      {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
      }
    }
  }
}
