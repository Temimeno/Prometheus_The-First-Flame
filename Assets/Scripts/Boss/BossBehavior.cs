using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float timer;
    public bool inRange;
    public GameObject triggerArea;
    public int AttackBoss = 1;
    public GameObject beam;
    public GameObject shootBeam;

    private float inTimer;
    private bool cooling = true;
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
            Attack01_Left_Vertical();
        }

        if(!cooling && AttackBoss == 2)
        {
            Attack01_Right_Horizontal();
        }

        if(cooling)
        {
            Cooldown();
        }
    }

    void Attack01_Left_Vertical()
    {
        timer = inTimer;
        cooling = true;
        AttackBoss = 2;
        Instantiate(beam, shootBeam.transform.position, Quaternion.identity);
        anim.SetTrigger("Attack01");
    }

    void Attack01_Right_Horizontal()
    {
        timer = inTimer;
        cooling = true;
        AttackBoss = 1;

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
