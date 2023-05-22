using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DateText : MonoBehaviour
{
    TextMeshProUGUI _text;
    DateTime _date;
    public Coroutine DateCoroutine;
    private void Awake() => _text = GetComponent<TextMeshProUGUI>();

    private void Start()
    {
        _text.text = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year;
        _date = DateTime.Now;
    }

    public void StartCountingDate()
    {
        DateCoroutine = StartCoroutine(IncreaseDate());
    }

    IEnumerator IncreaseDate()
    {
        while (true)
        {
            _date = _date.AddDays(1);
            _text.text = _date.Month.ToString() + "/" + _date.Day.ToString() + "/" + _date.Year;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
