using Unity.VisualScripting;
using UnityEngine;

public class FloorCollider : MonoBehaviour
{
    public bool canJump;

    public AudioSource audioSource;
    public AudioClip groundedSound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
         canJump = true;
         audioSource.PlayOneShot(groundedSound);

        }


    }

}
