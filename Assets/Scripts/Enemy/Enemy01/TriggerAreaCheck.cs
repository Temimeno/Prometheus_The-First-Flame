using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaCheck : MonoBehaviour
{
    private EnemyBehaviorCanWalk enemyParent;

    private void Awake()
    {
        enemyParent = GetComponentInParent<EnemyBehaviorCanWalk>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            enemyParent.target = col.transform;
            enemyParent.inRange = true;
            enemyParent.hotZone.SetActive(true);
        }
    }
}
