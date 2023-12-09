using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistence")]
public class SceneInfo : ScriptableObject
{
    public int spawningScene;
    public Vector3 playerSpawnPosition;
}
