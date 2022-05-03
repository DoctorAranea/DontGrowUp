using System.Collections;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private Transform[] spawnpoints;
    [SerializeField] private Transform[] groundTypes;

    private bool isActive = false;

    private IEnumerator SpawnNewGrounds()
    {
        int count = Random.Range(1, spawnpoints.Length + 1);
        switch (count)
        {
            case 1:
                {
                    int buf = Random.Range(0, spawnpoints.Length);
                    Instantiate(groundTypes[Random.Range(0, groundTypes.Length)],
                        spawnpoints[buf].position, 
                        groundTypes[0].rotation);
                    transform.position = spawnpoints[buf].position;
                    break;
                }
            case 2:
                {
                    Instantiate(groundTypes[Random.Range(0, groundTypes.Length)],
                        spawnpoints[0].position,
                        groundTypes[0].rotation);
                    yield return new WaitForSeconds(.5f);
                    Instantiate(groundTypes[Random.Range(0, groundTypes.Length)],
                        spawnpoints[1].position,
                        groundTypes[0].rotation);
                    transform.position = spawnpoints[Random.Range(0, 2)].position;
                    break;
                }
        }
        GlobalEventManager.SendNewGroundsSpawned();
    }

    private void Update()
    {
        GameObject[] destructible = GameObject.FindGameObjectsWithTag("Destructible");
        if (destructible.Length == 0 && !isActive)
        {
            isActive = true;
            StartCoroutine(SpawnNewGrounds());
        }
        if (destructible.Length > 0)
            isActive = false;
    }
}
