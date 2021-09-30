using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoubleChallenge : Challenge
{
  TextMeshPro expression1;
  TextMeshPro expression2;
  Transform fence;

  int fenceTopPosition = 2;
  int fenceBottomPosition = -1;

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
      expression1.text = GenerateExpression(true);
      expression2.text = GenerateExpression(false);
      SetFencePosition(fenceBottomPosition);
    }
    else
    {
      expression1.text = GenerateExpression(false);
      expression2.text = GenerateExpression(true);
      SetFencePosition(fenceTopPosition);
    }
  }

  void SetFencePosition(int y)
  {
    fence.localPosition = new Vector2(fence.localPosition.x, y);
  }
}

