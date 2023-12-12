using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    public SceneInfo sceneInfo;
    private Animator anim;
    public bool fire = false;

    public AudioSource audioClip;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("Player"))
        {
            gm.lastCheckpointPos = transform.position;
            gm.checkPointAtScene = SceneManager.GetActiveScene().buildIndex;
            
            if(fire == false)
            {
                anim.SetTrigger("OpenFire");
                StartCoroutine(ChangeFire());
            }

            sceneInfo.playerSpawnPosition = gm.lastCheckpointPos;
            sceneInfo.spawningScene = gm.checkPointAtScene;
        }
    }

    IEnumerator ChangeFire()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Fire", true);
        audioClip.Play();
        fire = true;
    }
}
