using Unity.VisualScripting;
using UnityEngine;

public class BatTrigger : MonoBehaviour
{

    public Transform[] bat; //[] para transformar em vetor(ou conjunto)
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
            foreach (Transform obj in bat)
            {
                obj.GetComponent<BatController>().enabled = true;
            }
        }
    }
}
