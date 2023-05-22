using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TradePrice : MonoBehaviour
{
    public bool TradeStarted = false;

    float _startYPosition;
    [SerializeField] float _basePrice, _yMultiplier;
    public TextMeshProUGUI _text;
    [SerializeField] TextMeshProUGUI _text2;


    private void Awake()
    {
        _startYPosition = transform.position.y;
    }

    private void Update()
    {
        if (!TradeStarted) { return; }
        float yDifference = transform.position.y - _startYPosition;
        _text.text = "$" + (yDifference * _yMultiplier * _basePrice).ToString("F2") ;
        _text2.text = "Sell";
    }
}
