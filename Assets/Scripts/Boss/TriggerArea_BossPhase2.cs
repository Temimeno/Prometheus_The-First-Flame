using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea_BossPhase2 : MonoBehaviour
{
    private BossBehaviorPhase2 bossparentPhase2;


    void Awake()
    {
        bossparentPhase2 = GetComponentInParent<BossBehaviorPhase2>();
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            bossparentPhase2.inRange = true;
        }
    }
}
