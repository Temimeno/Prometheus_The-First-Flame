using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector3 playerPosition;
    public VectorValue playerPositionStorage;

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player") && !collider2D.isTrigger)
        {
            playerPositionStorage.intialValue = playerPosition;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
