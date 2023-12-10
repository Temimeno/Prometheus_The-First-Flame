using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float timer;
    public bool inRange;
    public GameObject triggerArea;
    
    private float inTimer;
    private int AttackBoss = 1;
    private bool cooling;
    private Animator anim;
    private BossHealth bossHealth;
    

    void Awake()
    {
        anim = GetComponent<Animator>();
        bossHealth = GetComponentInParent<BossHealth>();
        inTimer = timer;
    }

    void Update()
    {
        if(inRange)
        {
            BossLogic();
        }
    }

    void BossLogic()
    {
        if(!cooling && AttackBoss == 1)
        {
            Attack01();
        }

        if(cooling)
        {
            Cooldown();
        }
    }

    void Attack01()
    {
        timer = inTimer;
        cooling = true;
        AttackBoss = 2;

        anim.SetTrigger("Attack01");
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            cooling = false;
            timer = inTimer;
        }

    }
}
