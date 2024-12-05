using UnityEngine;

public class BearTrap : MonoBehaviour
{
    Transform player;
    public Transform skin;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(clip);
            
            skin.GetComponent<Animator>().Play("Stuck", -1);

            collision.transform.position = transform.position;
            collision.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            collision.GetComponent<PlayerController>().skin.GetComponent<Animator>().SetBool("PlayerRun", false);
            collision.GetComponent<PlayerController>().skin.GetComponent<Animator>().Play("Player Idle", -1);

            GetComponent<BoxCollider2D>().enabled = false;

            player = collision.transform;

            collision.GetComponent<PlayerController>().enabled = false;

            Invoke("ReleasePlayer", 2);
        }
    }
    void ReleasePlayer()
    {
        player.GetComponent<PlayerController>().enabled = true;
    }
}

