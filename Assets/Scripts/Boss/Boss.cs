using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject boss;
    public GameObject Box;
    public GameObject bossHealthBar;
    public GameObject boxActive;
    public Animator anim;
    public GameObject RoomBlock;
    public GameObject Platform;
    public GameObject LoopMusic;



    void Start()
    {
        boss.SetActive(false);
        bossHealthBar.SetActive(false);
    }
    void awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Destroy(Box);
            Destroy(boxActive);
            boss.SetActive(true);
            bossHealthBar.SetActive(true);
            RoomBlock.SetActive(true);
            Platform.SetActive(true);
            LoopMusic.SetActive(true);
            anim.SetTrigger("OpenBoss");
        }
    }

    
}
