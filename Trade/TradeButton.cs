using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class TradeButton : MonoBehaviour
{
    [SerializeField] SplineFollower _follower;
    [SerializeField] float _speed = 0.5f;
    [SerializeField] GameObject _fx, _endButton;
    bool _firstStage = true;

    TradePrice _tradePrice;
    DateText _dateText;
    TradeVFX _tradeVFX;
    FollowerSpeed _followerSpeed;


    private void Awake()
    {
        _tradePrice = FindObjectOfType<TradePrice>();
        _dateText = FindObjectOfType<DateText>(true);
        _tradeVFX = FindObjectOfType<TradeVFX>();
        _followerSpeed = FindObjectOfType<FollowerSpeed>();
    }
    public void OnTradeButtonClicked()
    {
        if (_firstStage)
        {
            _firstStage = false;
            _follower.followSpeed = _speed;
            _tradePrice.TradeStarted = true;
            _dateText.StartCountingDate();
            _tradeVFX.StartVFXSpawn();
            _followerSpeed.StartSpeedCalculation();
        }

        else
        {
            _tradePrice.enabled = false;
            StopCoroutine(_dateText.DateCoroutine);
            _dateText.enabled = false;
            StopCoroutine(_tradeVFX.TradeRoutine);
            _tradeVFX.enabled = false;
            StopCoroutine(_followerSpeed.SpeedCoroutine);
            _follower.followSpeed = 0f;
            _fx.SetActive(true);
            _endButton.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
