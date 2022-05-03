using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objPrefabs;
    [SerializeField] private GameObject[] decorations;
    [SerializeField] private float range = 3.5f;

    void Start()
    { 
        Spawn(objPrefabs, 10, 30, range);
        Spawn(decorations, 0, 4, range);
    }

    private void Spawn(GameObject[] objects, int minCount, int maxCount, float spawnRange)
    {
        int spawnCount = Random.Range(minCount, maxCount + 1);
        for (int i = 0; i < spawnCount; i++)
        {
            float x = transform.position.x + Random.Range(-spawnRange, spawnRange);
            float y = transform.position.y + 0.5f;
            float z = transform.position.z + Random.Range(-spawnRange, spawnRange);
            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

            Instantiate(objects[Random.Range(0, objects.Length)], new Vector3(x, y, z), rotation, transform);
        }
    }
}
