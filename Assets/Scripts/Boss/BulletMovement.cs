using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] public float Speed = 1;
    [SerializeField] public float Delay = 3;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Speed * Time.deltaTime;

        Destroy(this.gameObject, Delay);
    }
}
