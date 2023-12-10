using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public float timer;
    public GameObject hotZone;
    //public GameObject BossPhase2;

    private Animator anim;
    private float distance;
    private bool cooling;
    private float inTimer;
    private BossHealth bossHealth;

    void Awake()
    {
        anim = GetComponent<Animator>();
        inTimer = timer;
    }
}
