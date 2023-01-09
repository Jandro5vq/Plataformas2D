using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UP1Logic : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("UP1 -> Triggered");
            collision.transform.GetChild(1).gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
