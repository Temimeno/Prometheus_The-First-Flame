using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathButtons : MonoBehaviour
{
    public Stats stats;
    public Status status;
    public Souls playerSouls;
    public SceneInfo sceneInfo;
    public SceneInfo clearOldScene;
    public VectorValue vectorValue;
    public VectorValue clearOldPosition;
    public PathNumber pathNumber;
    public AudioSource audioClip1;
    public AudioSource audioClip2;
    public AudioSource audioClip3;

    public void StandardPath()
    {
        stats.Vitality = 10;
        stats.Agility = 8;
        stats.Stength = 8;
        stats.Intelligence = 5;
        stats.Luck = 5;

        pathNumber.path = false;

        audioClip1.Play();
        StartCoroutine(PlaySong());

    }

    public void SwiftPath()
    {
        stats.Vitality = 6;
        stats.Agility = 15;
        stats.Stength = 5;
        stats.Intelligence = 5;
        stats.Luck = 5;
        
        pathNumber.path = false;
        
        audioClip2.Play();
        StartCoroutine(PlaySong());
    }

    public void HyperPath()
    {
        stats.Vitality = 4;
        stats.Agility = 10;
        stats.Stength = 13;
        stats.Intelligence = 5;
        stats.Luck = 5;
        
        pathNumber.path = false;

        audioClip3.Play();
        StartCoroutine(PlaySong());
        
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

        playerSouls.soul = 0;
    }

    IEnumerator PlaySong()
    {
        yield return new WaitForSeconds(1f);
        SetStatus();
        ChangeScene();
    }
}
