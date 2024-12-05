using Unity.VisualScripting;
using UnityEngine;

public class GhostController : MonoBehaviour
{

    public Transform a;
    public Transform b;

    public Transform skin;
    public bool goRight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (goRight == true)
        {
            skin.localScale = new Vector3(-1, 1, 1);
            if (Vector2.Distance(transform.position, b.position) < 0.1f) 
            {
                transform.position = a.position;
            }
            transform.position = Vector2.MoveTowards(transform.position, b.position, 15f * Time.deltaTime);

        }
        else
        {
            skin.localScale = new Vector3(1, 1, 1);
            if (Vector2.Distance(transform.position, a.position) < 0.1f)
            {
                 transform.position = b.position;
            }
            transform.position = Vector2.MoveTowards(transform.position, a.position, 15f * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Character>().PlayerDamage(1);
        }
    }
}
