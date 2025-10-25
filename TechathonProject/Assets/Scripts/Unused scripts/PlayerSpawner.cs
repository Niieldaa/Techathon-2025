using UnityEngine;
using Fusion;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab; // Player prefab to spawn

    public void SpawnPlayer(NetworkRunner runner, PlayerRef player)
    {
        if (runner.IsServer)
        {
            Vector3 spawnPosition = GetSpawnPosition();
            NetworkObject playerObject = runner.Spawn(playerPrefab, spawnPosition, Quaternion.identity);
            playerObject.GetComponent<NetworkRig>().health = 100;  // Initialize player health
        }
    }

    private Vector3 GetSpawnPosition()
    {
        // Return a random spawn position or predefined one
        return new Vector3(Random.Range(-10f, 10f), 1f, Random.Range(-10f, 10f));
    }
}