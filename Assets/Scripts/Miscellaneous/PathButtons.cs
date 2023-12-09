using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathButtons : MonoBehaviour
{
    public Stats stats;

    public void StandardPath()
    {
        stats.Vitality = 10;
        stats.Agility = 7;
        stats.Stength = 7;
        stats.Intelligence = 5;
        stats.Luck = 5;
        ChangeScene();
    }

    public void SwiftPath()
    {
        stats.Vitality = 6;
        stats.Agility = 12;
        stats.Stength = 6;
        stats.Intelligence = 5;
        stats.Luck = 5;
        ChangeScene();
    }

    public void HyperPath()
    {
        stats.Vitality = 4;
        stats.Agility = 10;
        stats.Stength = 10;
        stats.Intelligence = 5;
        stats.Luck = 5;
        ChangeScene();
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(2);
    }
}
