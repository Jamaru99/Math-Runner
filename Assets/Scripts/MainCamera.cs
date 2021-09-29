using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
  Transform player;
  public float minY, maxY;

  void FixedUpdate()
  {
    player = GameObject.Find("Player").GetComponent<Transform>();
    transform.position = new Vector3(player.position.x + 7, Mathf.Clamp(player.position.y, minY, maxY), -10);
  }
}
