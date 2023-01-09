using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject otherPortal;
    [SerializeField] public bool Enabled = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            otherPortal.GetComponent<Portal>().enabled = false;

            if (this.name == "Portal_A")
            {
                collision.gameObject.transform.position = new Vector2(otherPortal.transform.position.x - 1.4f, otherPortal.transform.position.y + 0.2f);
            }
            else
            {
                collision.gameObject.transform.position = new Vector2(otherPortal.transform.position.x + 1.4f, otherPortal.transform.position.y + 0.2f);
            }
            
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enabled = true;
        }
    }
}