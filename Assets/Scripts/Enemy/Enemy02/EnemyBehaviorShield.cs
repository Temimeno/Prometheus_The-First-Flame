using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorShield : MonoBehaviour
{
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public Transform LeftLimit;
    public Transform RightLimit;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea;

    private Animator anim;
    private Rigidbody2D rb;
    private float distance;
    private bool attackMode;
    private bool cooling;
    private float inTimer;

    void Awake()
    {
        SelectTarget();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        inTimer = timer;
    }

    void Update()
    {
        if(!attackMode)
        {
            Move();
        }
        if(!InsideOfLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
        {
            SelectTarget();
        }
        if(inRange)
        {
            EnemyLogic();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);


        if (cooling)
        {
            Cooldown();
            
        }
    }

    void Move()
    {
        anim.SetBool("Walk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }



    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        
        anim.SetBool("Attack", false);
        
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = inTimer;
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideOfLimits()
    {
        return transform.position.x > LeftLimit.position.x && transform.position.x < RightLimit.position.x;
    }

    public void SelectTarget()
    {
        float distanceToLeft = Vector3.Distance(transform.position, LeftLimit.position);
        float distanceToRight = Vector3.Distance(transform.position, RightLimit.position);

        if(distanceToLeft > distanceToRight)
        {
            target = LeftLimit;
        }
        else
        {
            target = RightLimit;
        }

        Flip();
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x) 
        {
            rotation.y = 0;
        }
        else
        {
            rotation.y = 180;
        }


        transform.eulerAngles = rotation;
    }
}

