using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
  public GameObject doubleChallenge;

  Rigidbody2D rigidbody;
  GameObject spawn;

  bool canJump = false;
  float jumpForce = 1200;
  public float speed = 1f;

  void Start()
  {
    rigidbody = GetComponent<Rigidbody2D>();
    spawn = GameObject.Find("Spawn");
  }

  void FixedUpdate()
  {
    transform.Translate(speed * Time.deltaTime, 0, 0);
    if (Input.GetKeyDown("space") && canJump)
    {
      rigidbody.AddForce(new Vector2(0, jumpForce));
      canJump = false;
    }
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Ground")
    {
      canJump = true;
    }
    if (other.gameObject.tag == "Death")
    {
      transform.position = spawn.transform.position;
    }
    if (other.gameObject.tag == "GroundSpeed")
    {
      speed += 5;
    }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "GroundSpeed")
    {
      speed += 5;
      SpawnDoubleChallenge();
    }
  }

  void OnTriggerExit2D(Collider2D other)
  {
    if (other.tag == "GroundSpeed")
    {
      speed -= 5;
    }
  }

  void SpawnDoubleChallenge()
  {
    Instantiate(doubleChallenge, new Vector2(transform.position.x + 10f, -2.5f), Quaternion.identity);
  }
}
