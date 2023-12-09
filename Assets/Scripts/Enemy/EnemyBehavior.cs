using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform rayCast;
    public LayerMask raycastMesk;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public Transform LeftLimit;
    public Transform RightLimit;

    private Transform target;
    private RaycastHit2D hit;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float inTimer;

    void Awake()
    {
        SelectTarget();
        anim = GetComponent<Animator>();
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
            hit = Physics2D.Raycast(rayCast.position, -transform.right, rayCastLength, raycastMesk);
            RaycastDebugger();
        }

        if(hit.collider != null)
        {
            EnemyLogic();
        }
        else if(hit.collider == null)
        {
            inRange = false;
        }

        if(inRange == false)
        {
            
            StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            target = col.transform;
            inRange = true;
            Flip();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if(distance > attackDistance)
        {
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
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

    void Attack()
    {
        timer = inTimer; 
        attackMode = true;

        anim.SetBool("Walk", false);
        anim.SetBool("Attack",true); 
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


    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, -transform.right * rayCastLength, Color.red);
            
        }
        else if(attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, -transform.right * rayCastLength, Color.green);
            Debug.Log("Player");
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

    private void SelectTarget()
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

    void Flip()
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
