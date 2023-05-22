using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDropSingle : DragDrop
{
    [SerializeField] Sprite _spriteToChange;
    Image _image;

    protected override void Awake()
    {
        base.Awake();
        _image = GetComponent<Image>();
    }
    public void OnSingleSprite()
    {
        _image.sprite = _spriteToChange;
    }
}
