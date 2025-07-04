
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject obstaclePrefab;

    [SerializeField] GameObject tallObstaclePrefab;
    [SerializeField] float tallObstacleChance = 0.2f; // 20% chance to spawn a tall obstacle
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2f);
    }

    public void SpawnObstacle()
    {
        // Randomly decide whether to spawn a tall obstacle
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if (random < tallObstacleChance)
        {
            obstacleToSpawn = tallObstaclePrefab; // Choose the tall obstacle prefab
        }
        //Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5); // Assuming you have 3 spawn points
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform; // Get the spawn point
        // Spawn the obstacle at the position
        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }


    public void SpawnCoins()
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }   
    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }
        point.y =  1f; // Set a fixed height for the coins
        return point;
    }
}
