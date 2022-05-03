using UnityEngine;
using TMPro;

public class DestroyedCounter : MonoBehaviour
{
    private void Start()
    {
        GlobalEventManager.OnDestroyedCounterUpdated.AddListener(UpdateCounter);
    }
    
    private void UpdateCounter(int destroyedCount)
    {
        GetComponent<TextMeshProUGUI>().text = $"{destroyedCount}";
    }
}
