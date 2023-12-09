using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea_Shield : MonoBehaviour
{
    private EnemyBehaviorShield enemyParentShield;

    private void Awake()
    {
        enemyParentShield = GetComponentInParent<EnemyBehaviorShield>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            enemyParentShield.target = col.transform;
            enemyParentShield.inRange = true;
            enemyParentShield.hotZone.SetActive(true);
        }
    }
}