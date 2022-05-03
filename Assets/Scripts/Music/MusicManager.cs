using UnityEngine;

public class MusicManager : MonoBehaviour
{
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        GameObject[] music = GameObject.FindGameObjectsWithTag("Music");
        if (music.Length == 1)
        {
            audioSource.Play();
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
}
