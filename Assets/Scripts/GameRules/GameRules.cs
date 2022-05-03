using UnityEngine;

public class GameRules : MonoBehaviour
{
    private static int destroyedCount;
    private Transform player;

    private void Awake()
    {
        GlobalEventManager.OnDestructibleDestroyed.AddListener(IncrementDestroyedCounter);
        GlobalEventManager.OnPlayerDied.AddListener(DestroyedCountToZero);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        CheckGameOver();
    }

    private void IncrementDestroyedCounter()
    {
        destroyedCount++;
        GlobalEventManager.SendDestroyedCounterUpdated(destroyedCount);
    }

    private void DestroyedCountToZero()
    {
        destroyedCount = 0;
    }

    private void CheckGameOver()
    {
        if (player.position.y < -3f)
        {
            GlobalEventManager.SendPlayerDied();
        }
    }
}
