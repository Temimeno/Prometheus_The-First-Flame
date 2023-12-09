using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    public SceneInfo sceneInfo;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("Player"))
        {
            gm.lastCheckpointPos = transform.position;
            gm.checkPointAtScene = SceneManager.GetActiveScene().buildIndex;

            sceneInfo.playerSpawnPosition = gm.lastCheckpointPos;
            sceneInfo.spawningScene = gm.checkPointAtScene;
        }
    }
}
