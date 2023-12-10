using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float timer;
    public bool inRange;
    public GameObject triggerArea;
    public GameObject BeamHorizontal;
    public GameObject SpawnBeam;
    
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
            Attack01_Left();
        }

        if(!cooling && AttackBoss == 2)
        {
            Attack01_Right();
        }

        if(cooling)
        {
            Cooldown();
        }
    }

    void Attack01_Left()
    {
        timer = inTimer;
        cooling = true;
        AttackBoss = 2;

        
        anim.SetTrigger("Attack01");
    }

    void Attack01_Right()
    {
        timer = inTimer;
        cooling = true;
        AttackBoss = 1;

        Instantiate(BeamHorizontal, SpawnBeam.transform.position, Quaternion.identity);
        anim.SetTrigger("Attack01_Right");
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
