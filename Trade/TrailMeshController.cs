using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMeshController : MonoBehaviour
{
    [SerializeField] Material _color1, _color2;

    MeshTrailDrawer _trailShape;

    private void OnEnable() => _trailShape = GetComponent<MeshTrailDrawer>();

    public void OnDirectionChange()
    {
        if (_trailShape.material == _color1)
        {
            _trailShape.EndDrawing();
            _trailShape.material = _color2;
            _trailShape.StartDrawing();
        }
        else
        {
            _trailShape.EndDrawing();
            _trailShape.material = _color1;
            _trailShape.StartDrawing();
        }

    }
}
