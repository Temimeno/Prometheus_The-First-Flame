using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;

    public void GameEnd()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }
}
