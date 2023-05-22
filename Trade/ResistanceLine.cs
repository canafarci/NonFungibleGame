using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistanceLine : MonoBehaviour
{
    [HideInInspector] public float Speed, DashInterval;

    [SerializeField] MeshTrailDrawer _trailShape;
    bool _isActive = false;

    Coroutine _drawLineRoutine;

    private void Update()
    {
        if (!_isActive) { return; }

        Vector3 currentPos = transform.position;
        currentPos.x += Speed * Time.deltaTime;
        transform.localPosition = currentPos;
    }

    private void OnEnable() => _trailShape = GetComponent<MeshTrailDrawer>();

    public void StartDrawing()
    {
        _trailShape.enabled = true;
        _isActive = true;
        _drawLineRoutine = StartCoroutine(DashedLineDrawRoutine());
        StartCoroutine(DelayedStopDrawing(_drawLineRoutine));
    }

    IEnumerator DashedLineDrawRoutine()
    {
        while(true)
        {
            _trailShape.StartDrawing();
            yield return new WaitForSeconds(DashInterval);
            _trailShape.EndDrawing();
            yield return new WaitForSeconds(DashInterval / 3f);
        }
    }

    IEnumerator DelayedStopDrawing(Coroutine coroutineToStop)
    {
        yield return new WaitForSeconds(4f);
        StopCoroutine(coroutineToStop);
        _trailShape.EndDrawing();
    }

}
