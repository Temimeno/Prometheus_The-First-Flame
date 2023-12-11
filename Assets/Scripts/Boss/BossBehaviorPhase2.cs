using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviorPhase2 : MonoBehaviour
{
    public float timer;
    public bool inRange;
    public int AttackBoss = 1;
    public GameObject triggerArea;
    
    public GameObject BeamHorizontal;
    public GameObject BeamVertical;
    public GameObject BeamVerticalPhase2;

    public GameObject SpawnBeamHorizontal01;
    public GameObject SpawnBeamHorizontal02;
    
    public GameObject SpawnBeamHorizontalPhase02;

    public GameObject SpawnBeamVertical01;
    public GameObject SpawnBeamVertical02;
    public GameObject SpawnBeamVertical03;
    public GameObject SpawnBeamVertical04;

    public GameObject SpawnBeamVerticalPhase01;
    public GameObject SpawnBeamVerticalPhase02;
    public GameObject SpawnBeamVerticalPhase03;
    public GameObject SpawnBeamVerticalPhase04;
    public GameObject SpawnBeamVerticalPhase05;
    public GameObject SpawnBeamVerticalPhase06;
    public GameObject SpawnBeamVerticalPhase07;
    public GameObject SpawnBeamVerticalPhase08;

    
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
            Attack01_Left();
        }

        if(!cooling && AttackBoss == 2)
        {
            Attack01_Right();
        }

        if(!cooling && AttackBoss == 3)
        {
            Attack02();
        }

        if(!cooling && AttackBoss == 4)
        {
            Attack02_Right();
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

        Instantiate(BeamVertical, SpawnBeamVertical01.transform.position, Quaternion.identity);
        Instantiate(BeamVertical, SpawnBeamVertical02.transform.position, Quaternion.identity);
        Instantiate(BeamVertical, SpawnBeamVertical03.transform.position, Quaternion.identity);
        Instantiate(BeamVertical, SpawnBeamVertical04.transform.position, Quaternion.identity);
        
        anim.SetTrigger("Attack01");
    }

    void Attack01_Right()
    {
        timer = inTimer;
        cooling = true;
        AttackBoss = 3;

        Instantiate(BeamHorizontal, SpawnBeamHorizontal01.transform.position, Quaternion.identity);
        Instantiate(BeamHorizontal, SpawnBeamHorizontal02.transform.position, Quaternion.identity);
        
        anim.SetTrigger("Attack01_Right");
    }

    void Attack02()
    {
        timer = inTimer;
        cooling = true;
        AttackBoss = 4;

        Instantiate(BeamHorizontal, SpawnBeamHorizontalPhase02.transform.position, Quaternion.identity);

        Instantiate(BeamVerticalPhase2, SpawnBeamVerticalPhase01.transform.position, Quaternion.identity);
        Instantiate(BeamVerticalPhase2, SpawnBeamVerticalPhase03.transform.position, Quaternion.identity);
        Instantiate(BeamVerticalPhase2, SpawnBeamVerticalPhase05.transform.position, Quaternion.identity);
        Instantiate(BeamVerticalPhase2, SpawnBeamVerticalPhase07.transform.position, Quaternion.identity);

        anim.SetTrigger("Attack02");
    }

    void Attack02_Right()
    {
        timer = inTimer;
        cooling = true;
        AttackBoss = 1;

        Instantiate(BeamHorizontal, SpawnBeamHorizontalPhase02.transform.position, Quaternion.identity);

        Instantiate(BeamVerticalPhase2, SpawnBeamVerticalPhase02.transform.position, Quaternion.identity);
        Instantiate(BeamVerticalPhase2, SpawnBeamVerticalPhase04.transform.position, Quaternion.identity);
        Instantiate(BeamVerticalPhase2, SpawnBeamVerticalPhase06.transform.position, Quaternion.identity);
        Instantiate(BeamVerticalPhase2, SpawnBeamVerticalPhase08.transform.position, Quaternion.identity);

        anim.SetTrigger("Attack02_Right");
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