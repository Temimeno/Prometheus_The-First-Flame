using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck_Shield : MonoBehaviour
{
    private EnemyBehaviorShield enemyParentShield;
    private bool inRange;
    private Animator anim;

    private void Awake()
    {
        enemyParentShield = GetComponentInParent<EnemyBehaviorShield>();
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if(inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemt_Attack"))
        {
            enemyParentShield.Flip();

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            inRange = false;
            gameObject.SetActive(false);
            enemyParentShield.triggerArea.SetActive(true);
            enemyParentShield.inRange = false;
            enemyParentShield.SelectTarget();
        }
    } 
}

