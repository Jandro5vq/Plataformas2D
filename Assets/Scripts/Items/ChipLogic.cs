using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipLogic : MonoBehaviour
{

    [SerializeField] private bool Carry = false;
    [SerializeField] GameObject BDoor;
    private SpriteRenderer ChipSprite;
    private Animator ChipAnim;

    private void Start()
    {
        ChipSprite = GetComponent<SpriteRenderer>();
        ChipAnim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.U) && !Carry)
            {
                // Coloca el chip en la manos del robot
                Carry = true;
                ChipSprite.sortingOrder = 10;
                transform.SetParent(collision.transform);
                transform.localPosition = new Vector3(0.30f, -0.35f, 0);
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                ChipAnim.SetBool("Idle", true);
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.U) && Carry)
            {
                // Coloca el Chip en el suelo
                ChipSprite.sortingOrder = 0;
                transform.localPosition = new Vector3(0.6f, -0.75f, 0);
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                transform.SetParent(null);
                ChipAnim.SetBool("Idle", false);
                Carry = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PC_2")
        {
            Debug.Log("CHIP CORRECTO");
            BDoor.GetComponent<DoorMechanism>().Open = true;
        }
    }

}
