using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSpawnLoad : MonoBehaviour
{
    public SceneInfo sceneInfo;
    public VectorValue vectorValue;
    void Start()
    {
        SceneManager.LoadScene(sceneInfo.spawningScene);
        vectorValue.intialValue = sceneInfo.playerSpawnPosition;
    }
}
