using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public List<Vector2> Paradas;

    public float speed = 5.0f;
    int actualPos;

    bool Dentro = false;
    bool activo = false;

    private void Start()
    {
        transform.position = Paradas[0];
        actualPos = 0;
    }

    private void Update()
    {
        //Debug.Log("Posicion: " + actualPos);
        //Debug.Log("Avtivo: " + activo);
        //Debug.Log("Dentro: " + Dentro);

        if (Dentro && Input.GetKeyDown(KeyCode.U))
        {
            activo = true;
        }

        if (activo)
        {
            if (actualPos == 0)
            {
                MoveT(1);
            }
            else if (actualPos == 1)
            {
                MoveT(0);
            }
        }
    }

    void MoveT(int piso)
    {
        transform.position = Vector2.MoveTowards(transform.position, Paradas[piso], speed * Time.deltaTime);
        
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        if (pos == Paradas[piso])
        {
            actualPos = piso;
            activo = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("ENTRA EN EL ASCENSOR");
            Dentro = true;
            collision.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("SALE DEL ASCENSOR");
            Dentro = false;
            collision.transform.parent = null;
        }
    }

}
