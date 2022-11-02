using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck_Trigger : MonoBehaviour
{
    public bool Grounded;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Grounded = false;
        }
    }
}
