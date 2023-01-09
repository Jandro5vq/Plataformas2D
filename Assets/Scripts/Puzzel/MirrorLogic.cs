using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorLogic : MonoBehaviour
{
    [Range(0, 3)]
    public int angle = 0;

    public float speed = 1f;

    private void Start()
    {
        angle = Random.Range(0, 3);
    }

    private void Update()
    {
        if (angle == 0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), speed);
        }
        else if (angle == 1)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,0,90), speed);
        }
        else if (angle == 2)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 180), speed);
        }
        else if (angle == 3)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 270), speed);
        }
    }
}
