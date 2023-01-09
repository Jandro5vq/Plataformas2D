using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorMechanism : MonoBehaviour
{
    public enum Orientation { Horizontal, Vertical}
    public Orientation Tipo;
    public bool Open = false;
    public float MoveDist;
    public float Speed;

    public GameObject ToDestroy;

    public List<GameObject> Doors;

    public List<Vector3> Opos;
    public List<Vector3> Cpos;

    // Update is called once per frame
    private void Start()
    {
        
        Doors.Add(this.transform.GetChild(0).gameObject);
        Doors.Add(this.transform.GetChild(1).gameObject);
        
        Cpos.Add(new Vector3(Doors[0].transform.localPosition.x, Doors[0].transform.localPosition.y));
        Cpos.Add(new Vector3(Doors[1].transform.localPosition.x, Doors[1].transform.localPosition.y));

        PosUpdate();

    }

    private void Update()
    {
        PosUpdate();
        
        if (Open)
        {
            if (Doors[0].transform.localPosition != Opos[0])
            {
                DOpen(0);
            }
            if (Doors[1].transform.localPosition != Opos[1])
            {
                DOpen(1);
            }

            if(ToDestroy!= null)
            {
                Destroy(ToDestroy);
            }
        }
        else
        {
            if (Doors[0].transform.localPosition != Cpos[0])
            {
                DClose(0);
            }
            if (Doors[1].transform.localPosition != Cpos[1])
            {
                DClose(1);
            }
        }
    }

    private void PosUpdate()
    {
        Opos.Clear();
        
        if (Tipo == Orientation.Vertical)
        {
            Opos.Add(new Vector3(Cpos[0].x, Cpos[0].y + MoveDist));
            Opos.Add(new Vector3(Cpos[1].x, Cpos[1].y - MoveDist));
        }
        else
        {
            Opos.Add(new Vector3(Cpos[0].x - MoveDist, Cpos[0].y));
            Opos.Add(new Vector3(Cpos[1].x + MoveDist, Cpos[1].y));
        }
    }

    private void DOpen(int n)
    {
        Doors[n].transform.localPosition = Vector3.MoveTowards(Doors[n].transform.localPosition, Opos[n], Speed * Time.deltaTime);
    }

    private void DClose(int n)
    {
        Doors[n].transform.localPosition = Vector3.MoveTowards(Doors[n].transform.localPosition, Cpos[n], Speed * Time.deltaTime);
    }
}
