using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSouls : MonoBehaviour
{
    public Souls playerSouls;
    public Text soulsAmount;

    void Start()
    {
        
    }

    void Update()
    {
        soulsAmount.text = "" + playerSouls.soul;
    }
}
