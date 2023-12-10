using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathButtons : MonoBehaviour
{
    public Stats stats;
    public Status status;

    public void StandardPath()
    {
        stats.Vitality = 10;
        stats.Agility = 8;
        stats.Stength = 8;
        stats.Intelligence = 5;
        stats.Luck = 5;
        ChangeScene();
        SetStatus();
    }

    public void SwiftPath()
    {
        stats.Vitality = 6;
        stats.Agility = 15;
        stats.Stength = 5;
        stats.Intelligence = 5;
        stats.Luck = 5;
        ChangeScene();
        SetStatus();
    }

    public void HyperPath()
    {
        stats.Vitality = 4;
        stats.Agility = 10;
        stats.Stength = 13;
        stats.Intelligence = 5;
        stats.Luck = 5;
        ChangeScene();
        SetStatus();
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(2);
    }

    private void SetStatus()
    {
        status.MaxHealth = stats.Vitality * 10;
        status.CurrentHealth = status.MaxHealth;

        status.attackDamage = stats.Stength + (stats.Agility/4);

        status.dashingCooldown -= stats.Agility/30f;
    }
}
