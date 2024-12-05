using Unity.VisualScripting;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public Transform player;
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
        if (collision.CompareTag("Enemy"))
        {
            if (player.GetComponent<PlayerController>().comboNum == 1)
            {
                collision.GetComponent<Character>().life--;
            }
            if(player.GetComponent<PlayerController>().comboNum == 2)
            {
              collision.GetComponent<Character>().life -= 2; // -> -=2 == collision.GetComponent<Character>().life-2
            }
            

        }
    }
}
