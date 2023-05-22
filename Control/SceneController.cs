using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneController : MonoBehaviour
{
    bl_SceneLoader _sceneLoader;
    void Awake()
    {
        _sceneLoader = FindObjectOfType<bl_SceneLoader>();

    }
    public void CameraEvent()
    {

        _sceneLoader.LoadLevel("Drag n Drop Scene 2");

       
    }
}
