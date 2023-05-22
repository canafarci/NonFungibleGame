using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    public FacePart FacePart;

    SuccessChecker _successChecker;

    private void Awake() => _successChecker = FindObjectOfType<SuccessChecker>();

    private void OnEnable()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Draggable"))
            _successChecker.DragsLeftToWin++;
    }

}
