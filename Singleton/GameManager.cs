using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public References References { get { return _references; } }
    public AudioManager AudioManager { get { return _audioManager;} }
    
    References _references;
    AudioManager _audioManager;

    public static GameManager Instance { get; private set; }
    void Awake()
    {
        if (Instance)
            Destroy(gameObject);
        else
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }

        _references = GetComponent<References>();
        _audioManager = GetComponentInChildren<AudioManager>();
    }

    private void OnEnable() => SceneManager.activeSceneChanged += OnSceneLoaded;
    private void OnDisable() => SceneManager.activeSceneChanged -= OnSceneLoaded;

    private void OnSceneLoaded(Scene arg0, Scene arg1)
    {
        
    }
}
