using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea_Boss : MonoBehaviour
{
    private BossBehavior bossparent;

    private void Awake()
    {
        bossparent = GetComponentInParent<BossBehavior>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            bossparent.inRange = true;
        }
    }
}
