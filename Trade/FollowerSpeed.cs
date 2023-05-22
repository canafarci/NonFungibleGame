using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class FollowerSpeed : MonoBehaviour
{
    [SerializeField] SplineFollower _follower;
    [SerializeField] float _speed;
    float _xChange;
    Vector3 _lastPosition;
    public Coroutine SpeedCoroutine;

    public void StartSpeedCalculation()
    {
        SpeedCoroutine = StartCoroutine(SpeedCalculator());
    }

    IEnumerator SpeedCalculator()
    {
        while(true)
        {
            _lastPosition = transform.position;
            yield return new WaitForSeconds(Time.deltaTime);
            float change = _lastPosition.x - transform.position.x;
            if (change <= 0)
                change = Time.deltaTime;
            _follower.followSpeed = (_speed / 1000f) / change;
        }
    }
}
