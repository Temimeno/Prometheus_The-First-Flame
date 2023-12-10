using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float timer;
    public bool inRange;
    public GameObject triggerArea;
    public GameObject BossPhase1;
    public GameObject BossPhase2;

    public GameObject BeamHorizontal;
    public GameObject BeamVertical;
    public GameObject SpawnBeamHorizontal01;
    public GameObject SpawnBeamHorizontal02;
    public GameObject SpawnBeamHorizontal03;

    public GameObject SpawnBeamVertical01;
    public GameObject SpawnBeamVertical02;
    public GameObject SpawnBeamVertical03;
    
    
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
        if(bossHealth.Hp <= 1500)
        {   
            StartCoroutine(ChangeBossPhase());
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
        
        anim.SetTrigger("Attack01");
    }

    void Attack01_Right()
    {
        timer = inTimer;
        cooling = true;
        AttackBoss = 1;

        Instantiate(BeamHorizontal, SpawnBeamHorizontal01.transform.position, Quaternion.identity);
        Instantiate(BeamHorizontal, SpawnBeamHorizontal02.transform.position, Quaternion.identity);
        Instantiate(BeamHorizontal, SpawnBeamHorizontal03.transform.position, Quaternion.identity);
        
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

    IEnumerator ChangeBossPhase()
    {
        yield return new WaitForSeconds(1.0f);
        BossPhase2.SetActive(true);
        BossPhase1.SetActive(false);

    }
}
