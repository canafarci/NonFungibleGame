using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Config/New Config", order = 0)]
public class LevelConfig : ScriptableObject
{
    public AudioConfig CorrectSFX, MouseClickSFX;
    public GameObject CorrectVFX;
}

[System.Serializable]
public class AudioConfig
{
    public AudioClip Audio;
    public float Volume;
}
