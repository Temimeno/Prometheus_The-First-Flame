using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAudio : MonoBehaviour
{

    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [Header("-------- Audio Clip --------")]
    public AudioClip mainMenuBGM;

    public static MenuAudio instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        musicSource.clip = mainMenuBGM;
        musicSource.Play();
    }

    void Update()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentScene);

        if (currentScene > 1)
        {
            Destroy(gameObject);
        }
    }
}
