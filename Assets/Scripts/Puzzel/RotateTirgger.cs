using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTirgger : MonoBehaviour
{
    [SerializeField] private GameObject MirrorMount;

    private void OnTriggerStay2D(Collider2D collision)
    {       
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.U))
        {
            MirrorMount.GetComponent<MirrorLogic>().angle++;
            if (MirrorMount.GetComponent<MirrorLogic>().angle > 3)
            {
                MirrorMount.GetComponent<MirrorLogic>().angle = 0;
            }
        }
    }
}
