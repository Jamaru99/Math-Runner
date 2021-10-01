using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TripleChallenge : Challenge
{
  TextMeshPro expressionTop;
  TextMeshPro expressionMid;
  TextMeshPro expressionBottom;

  Transform spike1;
  Transform spike2;

  float spikeTopPosition = 4.75f;
  float spikeMidPosition = 1.9f;
  float spikeBottomPosition = -0.94f;

  void Start()
  {
    expressionTop = transform.GetChild(0).GetComponent<TextMeshPro>();
    expressionMid = transform.GetChild(1).GetComponent<TextMeshPro>();
    expressionBottom = transform.GetChild(2).GetComponent<TextMeshPro>();
    spike1 = transform.GetChild(3);
    spike2 = transform.GetChild(4);

    PopulateExpressions();
  }

  void PopulateExpressions()
  {
    int randomNumber = Random.Range(0, 3);
    switch (randomNumber)
    {
      case 0:
        expressionTop.text = GenerateExpression(true);
        expressionMid.text = GenerateExpression(false);
        expressionBottom.text = GenerateExpression(false);
        spike1.localPosition = new Vector2(spike1.localPosition.x, spikeMidPosition);
        spike2.localPosition = new Vector2(spike2.localPosition.x, spikeBottomPosition);
        break;
      case 1:
        expressionTop.text = GenerateExpression(false);
        expressionMid.text = GenerateExpression(true);
        expressionBottom.text = GenerateExpression(false);
        spike1.localPosition = new Vector2(spike1.localPosition.x, spikeTopPosition);
        spike2.localPosition = new Vector2(spike2.localPosition.x, spikeBottomPosition);
        break;
      case 2:
        expressionTop.text = GenerateExpression(false);
        expressionMid.text = GenerateExpression(false);
        expressionBottom.text = GenerateExpression(true);
        spike1.localPosition = new Vector2(spike1.localPosition.x, spikeTopPosition);
        spike2.localPosition = new Vector2(spike2.localPosition.x, spikeMidPosition);
        break;
    }
  }
}
