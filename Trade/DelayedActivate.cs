using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedActivate : MonoBehaviour
{
    [SerializeField] GameObject[] _objects;

    void Start()
    {
        StartCoroutine(DelayedSetActive());
    }

    IEnumerator DelayedSetActive()
    {
        yield return new WaitForSeconds(2f);
        foreach (GameObject item in _objects)
        {
            item.SetActive(true);
        }
    }
}
