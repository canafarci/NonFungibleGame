using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    public bool FoundTarget = false;

    protected RectTransform _rectTransform;
    protected Canvas _canvas;
    protected CanvasGroup _canvasGroup;
    protected Vector3 _startPosition;
    protected DraggableObject _draggableObject;

    public static event Action<FacePart> OnStartDrag;

    protected virtual void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = FindObjectOfType<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _startPosition = _rectTransform.localPosition;
        _draggableObject = GetComponent<DraggableObject>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        OnStartDrag?.Invoke(_draggableObject.FacePart);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!FoundTarget)
        {
            _rectTransform.localPosition = _startPosition;
            _canvasGroup.blocksRaycasts = true;
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        AudioConfig audioConfig = GameManager.Instance.References.LevelConfig.MouseClickSFX;
        GameManager.Instance.AudioManager.PlaySFX(audioConfig.Audio, audioConfig.Volume);
    }
}
