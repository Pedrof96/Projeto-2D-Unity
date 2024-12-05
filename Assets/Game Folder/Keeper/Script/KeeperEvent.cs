using UnityEngine;

public class KeeperEvent : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip attackSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void KeeperAttackSound()

    {
        audioSource.PlayOneShot(attackSound);
    }
}
