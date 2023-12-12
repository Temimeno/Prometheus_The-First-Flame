using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public SceneInfo sceneInfo;
    public VectorValue vectorValue;
    public PathNumber pathNumber;
    public Status playerStatus;
    public Souls playerSouls;

    public void ToPathSelection()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu()
    {
        playerStatus.CurrentHealth = playerStatus.MaxHealth;
        playerStatus.healQuantity = 3;
        playerSouls.soul /= 2;

        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadSave()
    {
        if (pathNumber.path == false)
        {
            SceneManager.LoadScene(sceneInfo.spawningScene, LoadSceneMode.Single);
            vectorValue.intialValue = sceneInfo.playerSpawnPosition;
        }
    }
}
