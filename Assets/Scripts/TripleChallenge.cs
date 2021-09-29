using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TripleChallenge : Challenge
{
  TextMeshPro expressionTop;
  TextMeshPro expressionMid;
  TextMeshPro expressionBottom;

  Transform fence1;
  Transform fence2;

  int fenceTop = 5;
  int fenceMid = 2;
  int fenceBottom = -1;

  void Start()
  {
    expressionTop = transform.GetChild(0).GetComponent<TextMeshPro>();
    expressionMid = transform.GetChild(1).GetComponent<TextMeshPro>();
    expressionBottom = transform.GetChild(2).GetComponent<TextMeshPro>();
    fence1 = transform.GetChild(3);
    fence2 = transform.GetChild(4);

    PopulateExpressions();
  }

  void PopulateExpressions()
  {
    int randomNumber = Random.Range(0, 3);
    switch (randomNumber)
    {
      case 0:
        expressionTop.text = GenerateEasyExpression(true);
        expressionMid.text = GenerateEasyExpression(false);
        expressionBottom.text = GenerateEasyExpression(false);
        fence1.localPosition = new Vector2(fence1.localPosition.x, fenceMid);
        fence2.localPosition = new Vector2(fence2.localPosition.x, fenceBottom);
        break;
      case 1:
        expressionTop.text = GenerateEasyExpression(false);
        expressionMid.text = GenerateEasyExpression(true);
        expressionBottom.text = GenerateEasyExpression(false);
        fence1.localPosition = new Vector2(fence1.localPosition.x, fenceTop);
        fence2.localPosition = new Vector2(fence2.localPosition.x, fenceBottom);
        break;
      case 2:
        expressionTop.text = GenerateEasyExpression(false);
        expressionMid.text = GenerateEasyExpression(false);
        expressionBottom.text = GenerateEasyExpression(true);
        fence1.localPosition = new Vector2(fence1.localPosition.x, fenceTop);
        fence2.localPosition = new Vector2(fence2.localPosition.x, fenceMid);
        break;
    }
  }
}
