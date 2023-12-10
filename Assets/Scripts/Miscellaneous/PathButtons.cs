using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathButtons : MonoBehaviour
{
    public Stats stats;
    public Status status;
    public SceneInfo sceneInfo;
    public SceneInfo clearOldScene;
    public VectorValue vectorValue;
    public VectorValue clearOldPosition;

    public void StandardPath()
    {
        stats.Vitality = 10;
        stats.Agility = 8;
        stats.Stength = 8;
        stats.Intelligence = 5;
        stats.Luck = 5;
        SetStatus();
        ChangeScene();
    }

    public void SwiftPath()
    {
        stats.Vitality = 6;
        stats.Agility = 15;
        stats.Stength = 5;
        stats.Intelligence = 5;
        stats.Luck = 5;
        SetStatus();
        ChangeScene();
    }

    public void HyperPath()
    {
        stats.Vitality = 4;
        stats.Agility = 10;
        stats.Stength = 13;
        stats.Intelligence = 5;
        stats.Luck = 5;
        SetStatus();
        ChangeScene();
    }

    private void ChangeScene()
    {
        sceneInfo.spawningScene = clearOldScene.spawningScene;
        sceneInfo.playerSpawnPosition = clearOldPosition.intialValue;

        SceneManager.LoadScene(sceneInfo.spawningScene, LoadSceneMode.Single);
        vectorValue.intialValue = sceneInfo.playerSpawnPosition;
    }

    private void SetStatus()
    {
        status.MaxHealth = stats.Vitality * 10;
        status.CurrentHealth = status.MaxHealth;

        status.attackDamage = stats.Stength + (stats.Agility/4);

        status.dashingCooldown = 0.8f - stats.Agility/30f;

        status.healQuantity = 3;
    }
}
