using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck_Raycast : MonoBehaviour
{
    [Header("Draw Raycast (Enable / Disable")]
    public bool Ray = true;
    [Header("Is Grounded?")]
    public bool grounded;
    [Header("Raycast settings")]
    public float length = 1;
    public LayerMask ground;
    public List<Vector3> OriginPoints;

    void Update()
    {
        grounded = false;
        for (int i = 0; i < OriginPoints.Count; i++)
        {
            Debug.DrawRay(transform.position + OriginPoints[i], Vector3.down * length, Color.green);
            
            RaycastHit2D hit = Physics2D.Raycast(transform.position + OriginPoints[i], Vector3.down, length, ground.value);

            if (hit.collider != null)
            {
                Debug.DrawRay(transform.position + OriginPoints[i], Vector3.down * hit.distance, Color.red);
                grounded = true;
            }
        }
    }
}
