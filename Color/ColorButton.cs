using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    [SerializeField] Sprite _outlineSprite, _regularSprite;
    Image _image;

    private void Awake() => _image = GetComponent<Image>();

    public static event Action OnColorButtonClicked;

    private void OnEnable()
    {
        OnColorButtonClicked += OnColorButtonClick;
    }

    private void OnColorButtonClick()
    {
        _image.sprite = _regularSprite;
    }

    public void OnSpriteButtonClicked()
    {
        OnColorButtonClicked?.Invoke();
        _image.sprite = _outlineSprite;
    }
}
