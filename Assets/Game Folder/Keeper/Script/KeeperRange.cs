using Unity.VisualScripting;
using UnityEngine;

public class KeeperRange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            transform.parent.GetComponent<Animator>().Play("KeeperAttack", -1);
        }
    }
}
