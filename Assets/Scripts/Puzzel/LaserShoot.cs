using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    private LineRenderer Laser;
    public Material mat;
    public GameObject Particulas;
    public int Rebotes;

    public bool Enabled = false;

    public LayerMask Layer;
    public List<Vector2> Indices;

    Vector2 Temppos;
    Vector2 Tempdir;
    Vector2 defPos;

    Vector2 Offset = new Vector2(.005f, .005f);

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


        if (Enabled == true || Input.GetKey(KeyCode.I) && this.transform.parent.name == "Robot")
        {
            castRay();
            Actuator();
        }
        else
        {
            Laser.positionCount = 0;
            Indices.Clear();
            Indices.Add(new Vector2(transform.position.x + 0.2f, transform.position.y));
            Indices.Add(new Vector2(transform.position.x + 0.6f, transform.position.y));
        }

        LaserUpdate();


    }

    void castRay()
    {
        Laser.positionCount = 0;

        Indices.Clear();

        Vector2 StartPoint = new Vector2(transform.position.x + 0.2f, transform.position.y);

        Indices.Add(StartPoint);

        PointCalc(StartPoint, transform.right);

        for (int i = 0; i < Rebotes; i++)
        {
            if (hit)
            {
                if (hit.collider.CompareTag("Mirror"))
                {
                    Vector2 NOffset = new Vector2(Offset.x * Tempdir.x, Offset.y * Tempdir.y);

                    defPos = Temppos + NOffset;

                    PointCalc(defPos, Tempdir);
                }
            }
        }
    }

    void PointCalc(Vector2 pos, Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(pos, dir, 9999, Layer);

        //Debug.DrawRay(pos, dir * hit.distance, Color.red);

        Tempdir = Vector2.Reflect(dir, hit.normal);
        Temppos = hit.point;

        this.hit = hit;

        if (hit)
        {
            Indices.Add(hit.point);
        }
    }

    void LaserUpdate()
    {
        if (Indices.Count == 1)
        {
            Indices.Add(Indices[0] + new Vector2(.3f, 0));
        }
        
        for (int x = 0; x < Indices.Count; x++)
        {
            Laser.positionCount++;
            Laser.SetPosition(x, Indices[x]);

            if (Indices.Count-1 == x)
            {
                Particulas.gameObject.transform.position = Indices[x];

                Vector2 dir = Indices[x] - Indices[x - 1];
                int sign = (dir.y >= 0) ? 1 : -1;
                float angle = Vector2.Angle(Vector2.right, Indices[x] - Indices[x - 1]) * sign;

                Particulas.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }

    void Actuator()
    {
        if (hit.collider.name == "Activator")
        {
            hit.collider.GetComponent<Activator>().active = true;
        }
    }
}
