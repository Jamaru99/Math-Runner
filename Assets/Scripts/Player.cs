using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject doubleChallengePrefab;
  public GameObject tripleChallengePrefab;

  public static int score = 0;

  Rigidbody2D rigidBody;
  Animator animator;

  bool canJump = false;
  bool canRun = false;
  float jumpForce = 1200;
  float speed = 4f;
  float startDelay = 1.7f;

  void Start()
  {
    rigidBody = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    Invoke("StartRunning", startDelay);
  }

  void FixedUpdate()
  {
    Run();
    Jump();
  }

  void StartRunning()
  {
    canRun = true;
    animator.Play("Player-Run");
  }

  void Run()
  {
    if (canRun)
    {
      transform.Translate(speed * Time.deltaTime, 0, 0);
    }
  }

  void Jump()
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
      speed = 9f;
    }
    if (other.tag == "Spawner")
    {
      SpawnChallenge();
    }
    if (other.tag == "Goal")
    {
      score++;
      UIManager.Instance.UpdateScoreUI(score);
    }
    if (other.tag == "Destroyer")
    {
      GameObject destroyableChallenge = other.transform.parent.gameObject;
      Destroy(destroyableChallenge);
    }
    if (other.tag == "Snail")
    {
      speed = 1.5f;
      Destroy(other.gameObject);
    }
  }

  void OnTriggerExit2D(Collider2D other)
  {
    if (other.tag == "GroundSpeed")
    {
      speed = 4f;
    }
  }

  void SpawnChallenge()
  {
    if (Challenge.ShouldSpawnTripleChallenge(score))
    {
      SpawnTripleChallenge();
    }
    else
    {
      SpawnDoubleChallenge();
    }
  }

  void SpawnDoubleChallenge()
  {
    Vector2 newPosition = new Vector2(transform.position.x + 44.9f, doubleChallengePrefab.transform.position.y);
    Instantiate(doubleChallengePrefab, newPosition, Quaternion.identity);
  }

  void SpawnTripleChallenge()
  {
    Vector2 newPosition = new Vector2(transform.position.x + 44.9f, tripleChallengePrefab.transform.position.y);
    Instantiate(tripleChallengePrefab, newPosition, Quaternion.identity);
  }

}
