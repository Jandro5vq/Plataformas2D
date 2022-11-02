using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Burst.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class LaserShoot : MonoBehaviour
{
    private LineRenderer Laser;
    public Material mat;
    public GameObject particles;
    public int maxBounces = 2;

    public List<Vector3> Indices;

    Vector2 Temppos;
    Vector3 Tempdir;

    bool active;

    RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        Laser = GetComponent<LineRenderer>();
        Laser.enabled = true;
        Laser.useWorldSpace = true;
        Laser.startColor = Color.cyan;
        Laser.endColor = Color.cyan;
        Laser.startWidth = 0.05f;
        Laser.endWidth = 0.05f;
        Laser.positionCount = 0;
        Laser.material = mat;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !active)
        {
            active = true;
        }
        else if (Input.GetKeyDown(KeyCode.Z) && active)
        {
            active = false;
        }

        if (active)
        {
            Laser.positionCount = 0;

            for (int i = 0; i < Indices.Count; i++)
            {
                Indices.RemoveAt(i);
            }

            Indices.Add(transform.position);

            PointCalc(transform.position, transform.right);

            for (int y = 0; y < maxBounces && hit.collider.CompareTag("Mirror"); y++)
            {
                Debug.Log(hit.collider.CompareTag("Mirror"));
                PointCalc(Temppos, Tempdir);
            }

            for (int x = 0; x < Indices.Count; x++)
            {
                Laser.positionCount++;
                Laser.SetPosition(x, Indices[x]);
            }
        }
    }

    void PointCalc(Vector3 pos, Vector3 dir)
    {
        Ray2D ray = new Ray2D(pos, dir);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        Debug.DrawRay(ray.origin, ray.direction * hit.distance);

        Tempdir = Vector3.Reflect(ray.direction, hit.normal);
        Temppos = hit.point;

        this.hit = hit;

        if (hit.collider != null)
        {
            Indices.Add(hit.point);
        }
    }
}
