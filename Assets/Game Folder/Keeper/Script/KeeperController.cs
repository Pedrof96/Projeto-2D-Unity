using UnityEngine;

public class KeeperController : MonoBehaviour
{

    public Transform a;
    public Transform b;
    public Transform skin;
    public Transform keeperRange;
    public bool goRight;

    public AudioSource audioSource;
    public AudioClip dieSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //comando de morte do keeper
        if (GetComponent<Character>().life <= 0)
        {
            audioSource.PlayOneShot(dieSound);
            this.enabled = false;
            keeperRange.GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
        //animação de ataque do keeper
        if (skin.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("KeeperAttack"))
        {
            return;
        }
        skin.localScale = new Vector3(1, 1, 1);
        //comando de movimentação dir esq
        if (goRight == true)
        {
            if (Vector2.Distance(transform.position, b.position) < 0.1f)
            {
                goRight = false;
            }
            transform.position = Vector2.MoveTowards(transform.position, b.position, 2.2f * Time.deltaTime);
        }
        else
        {
            skin.localScale = new Vector3(-1, 1, 1);
            if (Vector2.Distance(transform.position, a.position) < 0.1f)
            {
                goRight = true;
            }
            transform.position = Vector2.MoveTowards(transform.position, a.position, 2.2f * Time.deltaTime);
        }

    }
}
