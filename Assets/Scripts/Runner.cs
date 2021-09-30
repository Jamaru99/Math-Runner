using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
  public GameObject doubleChallengePrefab;

  Rigidbody2D rigidBody;

  bool canJump = false;
  int score = 0;
  float jumpForce = 1200;
  float speed = 4f;

  void Start()
  {
    rigidBody = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate()
  {
    Run();
    HandleJump();
  }

  void Run()
  {
    transform.Translate(speed * Time.deltaTime, 0, 0);
  }

  void HandleJump()
  {
    if ((Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)) && canJump)
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
    if (other.tag == "Goal")
    {
      score++;
      UIManager.Instance.UpdateScoreUI(score);
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
    Vector2 newPosition = new Vector2(transform.position.x + 45f, doubleChallengePrefab.transform.position.y);
    Instantiate(doubleChallengePrefab, newPosition, Quaternion.identity);
  }
}
