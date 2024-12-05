using UnityEngine;

public class FiretrapSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound()
    {
        audioSource.PlayOneShot(clip);
    }
}
