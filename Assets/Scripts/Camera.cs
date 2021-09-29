using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
  Transform player;
  public float minY, maxY, minX, maxX;

  void FixedUpdate()
  {
    player = GameObject.Find("Player").GetComponent<Transform>();
    transform.position = new Vector3(Mathf.Clamp(player.position.x + 7, minX, maxX), Mathf.Clamp(player.position.y, minY, maxY), -10);
  }
}
