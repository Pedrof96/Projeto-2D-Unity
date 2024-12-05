using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int life;
    public Transform skin;

    public Transform cam;
    public Text lifeCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            skin.GetComponent<Animator>().Play("Die", -1);

        }

        if (transform.CompareTag("Player"))
        {
            lifeCount.text = "x" + life.ToString();
        }
        
    }
    public void PlayerDamage(int value)
    {
        life = life - value;
        skin.GetComponent<Animator>().Play("Player Damage", 1);
        cam.GetComponent<Animator>().Play("CameraDamage", -1);
        GetComponent<PlayerController>().audioSource.PlayOneShot(GetComponent<PlayerController>().damageSound);
    }
}
