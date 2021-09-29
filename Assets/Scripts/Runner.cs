using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
  public GameObject doubleChallenge;

  Rigidbody2D rigidBody;

  bool canJump = false;
  float jumpForce = 1200;
  public float speed = 1f;

  void Start()
  {
    rigidBody = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate()
  {
    transform.Translate(speed * Time.deltaTime, 0, 0);
    if (Input.GetKeyDown("space") && canJump)
    {
      rigidBody.AddForce(new Vector2(0, jumpForce));
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
      GameManager.ReloadLevel();
    }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "GroundSpeed")
    {
      speed += 5;
    }
    if (other.tag == "Spawner")
    {
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
    Instantiate(doubleChallenge, new Vector2(transform.position.x + 45f, doubleChallenge.transform.position.y), Quaternion.identity);
  }
}
