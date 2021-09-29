using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoubleChallenge : Challenge
{
  TextMeshPro expression1;
  TextMeshPro expression2;
  Transform fence;

  int fenceTop = 2;
  int fenceBottom = -1;

  void Start()
  {
    expression1 = transform.GetChild(0).GetComponent<TextMeshPro>();
    expression2 = transform.GetChild(1).GetComponent<TextMeshPro>();
    fence = transform.GetChild(2);

    PopulateExpressions();
  }

  void PopulateExpressions()
  {
    int randomNumber = Random.Range(0, 2);
    if (randomNumber == 0)
    {
      expression1.text = GenerateEasyExpression(true);
      expression2.text = GenerateEasyExpression(false);
      SetFencePosition(fenceBottom);
    }
    else
    {
      expression1.text = GenerateEasyExpression(false);
      expression2.text = GenerateEasyExpression(true);
      SetFencePosition(fenceTop);
    }
  }

  void SetFencePosition(int y)
  {
    fence.localPosition = new Vector2(fence.localPosition.x, y);
  }
}

