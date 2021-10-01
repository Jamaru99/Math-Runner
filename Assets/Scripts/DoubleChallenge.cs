using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoubleChallenge : Challenge
{
  TextMeshPro expression1;
  TextMeshPro expression2;
  Transform spike;

  float spikeTopPosition = 2.01f;
  float spikeBottomPosition = -0.93f;

  void Start()
  {
    expression1 = transform.GetChild(0).GetComponent<TextMeshPro>();
    expression2 = transform.GetChild(1).GetComponent<TextMeshPro>();
    spike = transform.GetChild(2);

    PopulateExpressions();
  }

  void PopulateExpressions()
  {
    int randomNumber = Random.Range(0, 2);
    if (randomNumber == 0)
    {
      expression1.text = GenerateExpression(true);
      expression2.text = GenerateExpression(false);
      SetFencePosition(spikeBottomPosition);
    }
    else
    {
      expression1.text = GenerateExpression(false);
      expression2.text = GenerateExpression(true);
      SetFencePosition(spikeTopPosition);
    }
  }

  void SetFencePosition(float y)
  {
    spike.localPosition = new Vector2(spike.localPosition.x, y);
  }
}

