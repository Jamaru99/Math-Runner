using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge : MonoBehaviour
{
  void Awake()
  {
    SetLandscape();
  }

  protected string GenerateExpression(bool isTrue)
  {
    if (GameManager.mode == Mode.EASY)
    {
      return GenerateEasyExpression(isTrue);
    }
    if (GameManager.mode == Mode.MEDIUM)
    {
      return GenerateMediumExpression(isTrue);
    }
    if (GameManager.mode == Mode.HARD)
    {
      return GenerateHardExpression(isTrue);
    }
    return "";
  }

  protected string GenerateEasyExpression(bool isTrue)
  {
    int n1, n2, result;

    int maxNumber = Player.score / 2 + 6;
    int limit = Player.score >= 15 ? 3 : 2;

    Operation operation = GetRandomOperation(limit);

    if (operation == Operation.MULTIPLICATION)
    {
      n1 = Random.Range(0, 5);
      n2 = Random.Range(1, 10);
    }
    else
    {
      n1 = Random.Range(Player.score / 3, maxNumber);
      n2 = Random.Range(Player.score / 3, maxNumber);
    }

    switch (operation)
    {
      case Operation.SUM:
        result = isTrue ? n1 + n2 : n1 + n2 + Random.Range(1, maxNumber);
        return n1 + " + " + n2 + " = " + result;
      case Operation.MULTIPLICATION:
        result = isTrue ? n1 * n2 : n1 * n2 + Random.Range(1, maxNumber);
        return n1 + " x " + n2 + " = " + result;
      case Operation.SUBTRACTION:
        result = isTrue ? n1 - n2 : n1 - n2 + Random.Range(1, maxNumber);
        return n1 + " - " + n2 + " = " + result;
      default:
        return "";
    }
  }

  protected string GenerateMediumExpression(bool isTrue)
  {
    int n1, n2, result;

    int maxNumber = Player.score + 10;
    int limit = 3;

    Operation operation = GetRandomOperation(limit);

    if (operation == Operation.MULTIPLICATION)
    {
      n1 = Random.Range(5, 12);
      n2 = Random.Range(4, 10);
    }
    else
    {
      n1 = Random.Range(Player.score, maxNumber);
      n2 = Random.Range(Player.score, maxNumber);
    }

    switch (operation)
    {
      case Operation.SUM:
        result = isTrue ? n1 + n2 : n1 + n2 + Random.Range(1, maxNumber);
        return n1 + " + " + n2 + " = " + result;
      case Operation.MULTIPLICATION:
        result = isTrue ? n1 * n2 : n1 * n2 + Random.Range(1, maxNumber);
        return n1 + " x " + n2 + " = " + result;
      case Operation.SUBTRACTION:
        result = isTrue ? n1 - n2 : n1 - n2 + Random.Range(1, maxNumber);
        return n1 + " - " + n2 + " = " + result;
      default:
        return "";
    }
  }

  protected string GenerateHardExpression(bool isTrue)
  {
    int maxNumber = Player.score + 10;
    int limit = 4;

    Operation operation = GetRandomOperation(limit);

    switch (operation)
    {
      case Operation.SUM:
        float nSum1 = float.Parse(Random.Range(1.0f, 5.0f).ToString("N1"));
        float nSum2 = float.Parse(Random.Range(2.0f, 5.0f).ToString("N1"));
        float resultSum = isTrue ? nSum1 + nSum2 : nSum1 + nSum2 + Random.Range(1, maxNumber);
        return nSum1 + " + " + nSum2 + " = " + resultSum;
      case Operation.MULTIPLICATION:
        int nMult1 = Random.Range(Player.score, maxNumber);
        int nMult2 = Random.Range(Player.score, maxNumber);
        int resultMult = isTrue ? nMult1 * nMult2 : nMult1 * nMult2 + Random.Range(1, maxNumber);
        return nMult1 + " x " + nMult2 + " = " + resultMult;
      case Operation.SUBTRACTION:
        int nSub1 = Random.Range(Player.score, maxNumber);
        int nSub2 = Random.Range(Player.score, maxNumber);
        int resultSub = isTrue ? nSub1 - nSub2 : nSub1 - nSub2 + Random.Range(1, maxNumber);
        return nSub1 + " - " + nSub2 + " = " + resultSub;
      case Operation.DIVISION:
        int resultDiv = Random.Range(Player.score, maxNumber);
        int divider = Random.Range(2, 6);
        int dividend = resultDiv * divider;
        resultDiv = isTrue ? resultDiv : resultDiv + Random.Range(1, maxNumber);
        return dividend + " ÷ " + divider + " = " + resultDiv;
      default:
        return "";
    }
  }

  Operation GetRandomOperation(int limit)
  {
    int randomNumber = Random.Range(0, limit);
    switch (randomNumber)
    {
      case 0:
        return Operation.SUM;
      case 1:
        return Operation.SUBTRACTION;
      case 2:
        return Operation.MULTIPLICATION;
      case 3:
        return Operation.DIVISION;
      default:
        return new Operation();
    }
  }

  public static bool ShouldSpawnTripleChallenge(int score)
  {
    return score > 0
      && (GameManager.mode == Mode.MEDIUM && score % 8 == 0
      || GameManager.mode == Mode.HARD && score % 3 == 0);
  }

  void SetLandscape()
  {
    int randomNumber = Random.Range(0, 3);
    if (randomNumber == 0)
    {
      Destroy(transform.Find("House").gameObject);
      Destroy(transform.Find("Building").gameObject);
    }
    if (randomNumber == 1)
    {
      Destroy(transform.Find("Building").gameObject);
      Destroy(transform.Find("Tree").gameObject);
    }
    if (randomNumber == 2)
    {
      Destroy(transform.Find("House").gameObject);
      Destroy(transform.Find("Tree").gameObject);
    }
  }
}

public enum Operation
{
  SUM,
  SUBTRACTION,
  MULTIPLICATION,
  DIVISION
}
