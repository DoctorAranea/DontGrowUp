using UnityEngine;

public class MenuMethods : MonoBehaviour
{
    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }

    public void OpenMenu()
    {
        gameObject.SetActive(true);
    }
}
