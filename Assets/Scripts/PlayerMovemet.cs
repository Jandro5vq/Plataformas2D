using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemet : MonoBehaviour
{
    public float Speed = 10;
    public float force = 100;
    public int maxJumps = 1;
    public int jumps;

    public float hangTime = .2f;
    private float hangCounter;

    Rigidbody2D rb;
    Animator animator;
    GroundCheck_Raycast ground;


    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ground = GetComponent<GroundCheck_Raycast>();
    }

    void Update()
    {
        // ------------------- WALK LOGIC -------------------
        float horizontal = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(horizontal * Speed * Time.deltaTime, 0);

        if (Input.GetAxis("Horizontal") > 0)
        {
            animator.SetBool("Walk", true);
            if (ground.grounded)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
            transform.GetChild(0).gameObject.SetActive(true);
            transform.eulerAngles = new Vector3(0, 0, 0);
            ground.OriginPoints[0] = new Vector3(-.185f, -.96f, 0);
            ground.OriginPoints[1] = new Vector3(.31f, -.96f, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("Walk", true);
            if (ground.grounded)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
            transform.GetChild(0).gameObject.SetActive(true);
            transform.eulerAngles = new Vector3(0, 180, 0);
            ground.OriginPoints[1] = new Vector3(-.31f, -.96f, 0);
            ground.OriginPoints[0] = new Vector3(.185f, -.96f, 0);
        }
        else
        {
            animator.SetBool("Walk", false);
            transform.GetChild(0).gameObject.SetActive(false);
        }

        // ------------------- JUMP LOGIC -------------------

        if (ground.grounded)
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && hangCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, force);
            transform.GetChild(0).gameObject.SetActive(false);

        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .3f);
        }
    }  
}
