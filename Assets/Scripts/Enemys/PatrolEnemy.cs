using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    private Vector2 _start = Vector2.zero;
    private Vector2 _end = Vector2.zero;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private bool _Debug = false;

    // ------------------------------------------------------
    private void Start()
    {
        _start= transform.position;
        _end = transform.GetChild(0).transform.position;
        Destroy(transform.GetChild(0).gameObject);
    }

    private void OnDrawGizmos()
    {
        if (_Debug)
        {
            Gizmos.color = new Color(1, 0, 0, .35f);
            Gizmos.DrawLine(_start, _end);
        }
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time, _speed) / _speed;
        transform.position = Vector2.Lerp(_start, _end, t);
    }
}
