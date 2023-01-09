using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTP : MonoBehaviour
{
    [SerializeField] private Transform TPSpawn;
    [SerializeField] private GameObject Camera;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = TPSpawn.position;

            Camera.GetComponent<CameraFollow>().enabled = false;
            Camera.GetComponent<Camera>().orthographicSize = 10;
            Camera.transform.position = new Vector3(184.3f, 35, -10);


        }
    }
}
