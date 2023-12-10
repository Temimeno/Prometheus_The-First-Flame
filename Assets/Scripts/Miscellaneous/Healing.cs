using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    public Image hpbar;
    public Status status;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (status.healQuantity > 0)
                Heal();
        }
    }

    public void Heal()
    {
        status.CurrentHealth += status.healAmount;
        status.healQuantity -= 1;

        if (status.CurrentHealth > status.MaxHealth)
        {
            status.CurrentHealth = status.MaxHealth;
        }

        hpbar.fillAmount = status.CurrentHealth / status.MaxHealth;
    }
}
