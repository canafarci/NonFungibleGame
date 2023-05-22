using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorObject : MonoBehaviour
{
    [SerializeField] Sprite _target;
    [SerializeField] bool _notCounted = false;
    SuccessChecker _successChecker;
    

    public static event Action<FacePart> OnColorSuccesful;

    private void Awake() => _successChecker = FindObjectOfType<SuccessChecker>();

    private void OnEnable()
    {
        if (!_notCounted && gameObject.layer == LayerMask.NameToLayer("Draggable"))
            _successChecker.DragsLeftToWin++;
    }

    private void OnMouseDown()
    {
        print("called");
        GetComponent<Image>().sprite = _target;
        GetComponent<Collider2D>().enabled = false;
        OnColorSuccesful?.Invoke(FacePart.Null);
        PlayFX();
    }

    private void PlayFX()
    {
        GameObject VFX = Instantiate(GameManager.Instance.References.LevelConfig.CorrectVFX, GetComponent<RectTransform>().position, Quaternion.identity);
        Destroy(VFX, 3f);
    }
}
