using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge : MonoBehaviour
{
  public Operation operation;

  protected string GenerateEasyExpression(bool isTrue)
  {
    int n1 = Random.Range(0, 6);
    int n2 = Random.Range(0, 6);

    int result;

    switch (operation)
    {
      case Operation.SUM:
        result = isTrue ? n1 + n2 : n1 + n2 + Random.Range(1, 6);
        return n1 + " + " + n2 + " = " + result;
      case Operation.MULTIPLICATION:
        result = isTrue ? n1 * n2 : n1 * n2 + Random.Range(1, 6);
        return n1 + " x " + n2 + " = " + result;
      case Operation.SUBTRACTION:
        result = isTrue ? n1 - n2 : n1 - n2 + Random.Range(1, 6);
        return n1 + " - " + n2 + " = " + result;
      case Operation.DIVISION:
        result = isTrue ? n1 / n2 : n1 / n2 + Random.Range(1, 6);
        return n1 + " / " + n2 + " = " + result;
      default:
        return "";
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
