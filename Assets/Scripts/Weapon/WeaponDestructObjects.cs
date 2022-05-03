using UnityEngine;

public class WeaponDestructObjects : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AudioSource>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DestructibleAttributes>() != null)
        {
            Kill(other.transform);
            GlobalEventManager.SendDestructibleDestroyed();
        }
    }

    private void Kill(Transform other)
    {
        var attributes = other.GetComponent<DestructibleAttributes>();
        if (attributes.particle != null)
        {
            Instantiate(other.GetComponent<DestructibleAttributes>().particle,
                other.position,
                other.rotation);
        }
        if (attributes.destroySound != null)
        {
            audioSource.pitch = Random.Range(.85f, 1.1f);
            audioSource.PlayOneShot(attributes.destroySound);
        }
        Destroy(other.gameObject);
    }
}
