using UnityEngine;

public class Pause : MonoBehaviour
{

    void OnEnable()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void OnDisable()
    {
        Time.timeScale = 1;
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
