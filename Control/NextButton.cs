using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    Image _image;
    [SerializeField] Sprite _sprite;
    [SerializeField] GameObject _vFX;
    SuccessChecker _successChecker;
    [SerializeField] GameObject[] _itemsToDisable;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _successChecker = FindObjectOfType<SuccessChecker>();
    }
    private void OnEnable()
    {
        _successChecker.OnLevelSuccess += OnSuccess;
    }
    private void OnDisable()
    {
        _successChecker.OnLevelSuccess -= OnSuccess;
    }

    public void OnSuccess()
    {
        _image.sprite = _sprite;
        _vFX.SetActive(true);
    }

    public void OnNextButtonClicked()
    {
        foreach (GameObject item in _itemsToDisable)
        {
            item.SetActive(false);
        }
    }
}
