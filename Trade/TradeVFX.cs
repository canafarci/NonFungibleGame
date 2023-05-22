using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeVFX : MonoBehaviour
{
    [SerializeField] GameObject[] _vFXs;
    public Coroutine TradeRoutine;

    public void StartVFXSpawn()
    {
        TradeRoutine = StartCoroutine(SpawnRandomVFX());
    }

    IEnumerator SpawnRandomVFX()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            GameObject fx = Instantiate(_vFXs[((Func<int>)(() => UnityEngine.Random.Range(0, _vFXs.Length)))()], transform.position, transform.rotation, transform);
            Destroy(fx, 2f);
        }
    }


}
