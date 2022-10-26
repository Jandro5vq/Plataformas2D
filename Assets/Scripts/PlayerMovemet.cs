using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemet : MonoBehaviour
{
    public float Speed = 10;
    public float force = 10;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(horizontal * Speed * Time.deltaTime, 0);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, force));
        }
    }
}
