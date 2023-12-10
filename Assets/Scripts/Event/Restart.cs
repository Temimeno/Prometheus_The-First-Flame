using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public SceneInfo sceneInfo;
    public VectorValue vectorValue;
    public void RestartGame()
    {
        SceneManager.LoadScene(sceneInfo.spawningScene, LoadSceneMode.Single);
        vectorValue.intialValue = sceneInfo.playerSpawnPosition;
    }
}
