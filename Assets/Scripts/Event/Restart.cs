using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public SceneInfo sceneInfo;
    public VectorValue vectorValue;
    public Status status;
    public Souls playerSouls;
    public void RestartGame()
    {
        status.CurrentHealth = status.MaxHealth;
        status.healQuantity = 3;
        playerSouls.soul /= 2;

        SceneManager.LoadScene(sceneInfo.spawningScene, LoadSceneMode.Single);
        vectorValue.intialValue = sceneInfo.playerSpawnPosition;
    }
}
