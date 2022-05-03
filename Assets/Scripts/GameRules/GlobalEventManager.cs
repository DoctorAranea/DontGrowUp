using UnityEngine.Events;

public class GlobalEventManager
{
    public static UnityEvent<int> OnNewSceneRequested = new UnityEvent<int>();
    public static UnityEvent OnNewGroundsSpawned = new UnityEvent();
    public static UnityEvent<int> OnDestroyedCounterUpdated = new UnityEvent<int>();
    public static UnityEvent OnDestructibleDestroyed = new UnityEvent();
    public static UnityEvent OnPlayerDied = new UnityEvent();

    public static void SendNewSceneRequest(int newScene)
    {
        OnNewSceneRequested.Invoke(newScene);
    }

    public static void SendNewGroundsSpawned()
    {
        OnNewGroundsSpawned.Invoke();
    }

    public static void SendDestroyedCounterUpdated(int destroyedCounter)
    {
        OnDestroyedCounterUpdated.Invoke(destroyedCounter);
    }

    public static void SendDestructibleDestroyed()
    {
        OnDestructibleDestroyed.Invoke();
    }

    public static void SendPlayerDied()
    {
        OnPlayerDied.Invoke();
    }
}
