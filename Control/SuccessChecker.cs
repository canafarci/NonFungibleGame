using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessChecker : MonoBehaviour
{
    public int DragsLeftToWin;

    public event Action OnLevelSuccess;

    private void OnEnable()
    {
        ItemSlot.OnDragSuccessful += OnSuccess;
        ColorObject.OnColorSuccesful += OnSuccess;
    }
    private void OnDisable()
    {
        ItemSlot.OnDragSuccessful -= OnSuccess;
        ColorObject.OnColorSuccesful -= OnSuccess;
    }

    private void OnSuccess(FacePart facePart)
    {
        DragsLeftToWin--;
        if (DragsLeftToWin == 0)
            OnLevelSuccess?.Invoke();
    }
}
