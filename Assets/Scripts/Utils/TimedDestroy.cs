using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    [SerializeField] public float Delay = 1.0f;
    void Start()
    {
        Destroy(this.gameObject, Delay);
    }
}
