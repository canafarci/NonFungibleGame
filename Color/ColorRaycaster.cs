using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRaycaster : MonoBehaviour
{
    public LayerMask ColorLayer;

    public static event Action<FacePart> OnColorSuccesful;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ColorObject();
        }
    }

    private void ColorObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, ColorLayer);

        if (hit.collider != null)
        {
            //hit.transform.GetComponent<ColorObject>().OnClick();
            hit.collider.enabled = false;
            OnColorSuccesful?.Invoke(FacePart.Null);
        }
    }

}
