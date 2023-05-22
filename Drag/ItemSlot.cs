using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] FacePart _facePart;
    RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public static event Action<FacePart> OnDragSuccessful;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = eventData.pointerDrag.gameObject;
        FacePart draggedFacePart = draggedObject.GetComponent<DraggableObject>().FacePart;
        RectTransform dragRectTransform = draggedObject.GetComponent<RectTransform>();
        DragDropSingle dragDrop = draggedObject.GetComponent<DragDropSingle>();

        if (eventData.pointerDrag != null && draggedFacePart == _facePart)
        {
            SetRectTransformProperties(draggedObject, dragRectTransform);

            draggedObject.GetComponent<DragDrop>().enabled = false;
            GetComponent<Image>().raycastTarget = false;
            transform.GetChild(0).gameObject.SetActive(false);
            PlayFX();

            if (dragDrop != null)
                dragDrop.OnSingleSprite();

            OnDragSuccessful?.Invoke(_facePart);
        }
    }

    private void PlayFX()
    {
        GameObject VFX = Instantiate(GameManager.Instance.References.LevelConfig.CorrectVFX, _rectTransform.position, Quaternion.identity);
        Destroy(VFX, 3f);
    }

    private void SetRectTransformProperties(GameObject draggedObject, RectTransform dragRectTransform)
    {
        draggedObject.transform.parent = null;
        draggedObject.transform.parent = this.transform.parent;
        dragRectTransform.anchorMin = _rectTransform.anchorMin;
        dragRectTransform.anchorMax = _rectTransform.anchorMax;
        dragRectTransform.sizeDelta = _rectTransform.sizeDelta;
        dragRectTransform.offsetMax = _rectTransform.offsetMax;
        dragRectTransform.offsetMin = _rectTransform.offsetMin;
        dragRectTransform.pivot = _rectTransform.pivot;
        dragRectTransform.anchoredPosition = _rectTransform.anchoredPosition;
    }
}
