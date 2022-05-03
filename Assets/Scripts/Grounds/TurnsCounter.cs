using UnityEngine;

public class TurnsCounter : MonoBehaviour
{
    [SerializeField] private int turnsBeforeDestroying;

    private void Start()
    {
        turnsBeforeDestroying = 5;
        GlobalEventManager.OnNewGroundsSpawned.AddListener(TurnCounterDecrement);
    }

    private void Update()
    {
        if (turnsBeforeDestroying <= 0)
            Destroy(gameObject);
    }

    private void TurnCounterDecrement()
    {
        turnsBeforeDestroying--;
    }
}
