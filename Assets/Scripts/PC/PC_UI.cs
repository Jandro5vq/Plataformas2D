using UnityEngine;

public class PC_UI : MonoBehaviour
{
    public GameObject UI;
    
    private bool trg = false;
    private void Update()
    {
        if (trg && Input.GetKeyDown(KeyCode.U))
        {
            Time.timeScale = 0f;
            UI.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            trg = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            trg = false;
        }
    }
}
