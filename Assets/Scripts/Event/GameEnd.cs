using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject gameOverUI;
    public PlayerMovement playMovement;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "PlayerHealth")
            OpenGameEndUI();
    }
    void OpenGameEndUI()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
        playMovement.enabled = false;
    }
}
