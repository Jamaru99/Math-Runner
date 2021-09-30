using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge : MonoBehaviour
{
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

  protected string GenerateEasyExpression(bool isTrue, int maxNumber)
  {
    int n1, n2, result;

    int maxNumber = Player.score / 2 + 6;
    int limit = Player.score >= 15 ? 3 : 2;

    Operation operation = GetRandomOperation(limit);

    if (operation == Operation.MULTIPLICATION)
    {
      n1 = Random.Range(0, 10);
      n2 = Random.Range(1, 10);
    }
    else
    {
      n1 = Random.Range(0, maxNumber);
      n2 = Random.Range(0, maxNumber);
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

    int maxNumber = Player.score / 2 + 10;
    int limit = 3;

    Operation operation = GetRandomOperation(limit);

    if (operation == Operation.MULTIPLICATION)
    {
      n1 = Random.Range(1, 10);
      n2 = Random.Range(2, 12);
    }
    else
    {
      n1 = Random.Range(0, maxNumber);
      n2 = Random.Range(0, maxNumber);
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
  {/*
    case Operation.DIVISION:
        result = isTrue ? n1 / n2 : n1 / n2 + Random.Range(1, maxNumber);
        return n1 + " / " + n2 + " = " + result;*/
    return "";
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
}

public enum Operation
{
  SUM,
  SUBTRACTION,
  MULTIPLICATION,
  DIVISION
}
