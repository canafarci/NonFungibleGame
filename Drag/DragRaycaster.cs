using System;
using UnityEngine;

public class DragRaycaster : MonoBehaviour
{
    public LayerMask StartLayer, DraggingLayer, TargetLayer;

    private bool _isDragging;
    private GameObject _draggedObject;
    private Vector3 _objectStartPosition;
    private FacePart _objectType;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDragging();
        }

        if (_isDragging)
        {
            DraggingBehaviour();
        }

        if (Input.GetMouseButtonUp(0))
        {
            EndDragging();
        }
    }

    private void StartDragging()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, StartLayer);

        if (hit.collider != null)
        {
            _isDragging = true;
            _draggedObject = hit.collider.gameObject;
            _objectStartPosition = hit.collider.transform.position;
            _objectType = hit.transform.GetComponent<DraggableObject>().FacePart;
        }
    }

    private void DraggingBehaviour()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, DraggingLayer);

        if (hit.collider != null)
        {
            _draggedObject.transform.position = hit.point;
        }
    }

    private void EndDragging()
    {
        if (!_isDragging) { return; }

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, TargetLayer);

        if (hit.collider != null && hit.transform.GetComponent<DraggableObject>().FacePart == _objectType)
        {
            _draggedObject.transform.position = hit.collider.gameObject.transform.position;
            hit.collider.enabled = false;
            _isDragging = false;
            _draggedObject.GetComponent<Collider2D>().enabled = false;
            _draggedObject = null;
            _objectType = FacePart.Null;

        }
        else
        {
            _draggedObject.transform.position = _objectStartPosition;
            _isDragging = false;
            _draggedObject = null;
            _objectType = FacePart.Null;
        }
    }
}
