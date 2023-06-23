using UnityEngine;

public class UserSpawner : MonoBehaviour
{
    public GameObject[] Spawns;

    private void Awake() =>
        GameObject.DontDestroyOnLoad(gameObject);

    public Transform SpawnPoint()
    {
        var random = new System.Random();
        var spawnIndex = random.Next(0, Spawns.Length);
        return Spawns[spawnIndex].transform;
    }
}