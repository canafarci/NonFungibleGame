using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DottedReference : MonoBehaviour
{
    [SerializeField] FacePart _facePart;
    [SerializeField] Sprite _greenSprite, _redSprite, _graySprite;
    Image _image;
    bool _isFinished = false;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    private void OnEnable()
    {
        DragDrop.OnStartDrag += OnStartDrag;
        ItemSlot.OnDragSuccessful += OnDragSuccessful;
    }

    private void OnDisable()
    {
        DragDrop.OnStartDrag -= OnStartDrag;
        ItemSlot.OnDragSuccessful -= OnDragSuccessful;
    }

    private void OnDragSuccessful(FacePart facePart)
    {
        if (facePart == _facePart)
        {
            _isFinished = true;
            _image.enabled = false;
        }

        if (!_isFinished)
        {
            _image.sprite = _graySprite;
        }
            
    }   


    public void OnStartDrag(FacePart facePart)
    {
        if (facePart != _facePart)
            _image.sprite = _redSprite;
        else
            _image.sprite = _greenSprite;
    }
}
