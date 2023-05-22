using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistanceLineController : MonoBehaviour
{
    [SerializeField] float _speed, _dashInterval;
    

    private void Awake()
    {
        foreach (ResistanceLine rl in GetComponentsInChildren<ResistanceLine>())
        {
            rl.Speed = _speed;
            rl.DashInterval = _dashInterval;
        }
    }
}
