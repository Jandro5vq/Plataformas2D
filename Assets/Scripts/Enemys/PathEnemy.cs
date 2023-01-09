using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEnemy : MonoBehaviour
{
    [SerializeField] private bool _Debug = false;
    [SerializeField] private float speed;

    private SpriteRenderer Sprite;

    private List<Vector2> Points = new List<Vector2>();
    private int x = 1;
    private Vector2 ActPos;
    private Vector2 OldPos;

    private void Start()
    {
        Sprite= GetComponent<SpriteRenderer>();

        Points.Clear();
        for (int i = 0; i < transform.childCount + 1; i++)
        {
            if (i == 0)
            {
                Points.Add(transform.position);
            }
            else
            {
                Points.Add(transform.GetChild(i - 1).position);
                Destroy(transform.GetChild(i - 1).gameObject);
            }
        }

        OldPos = transform.position;
    }

    void Update()
    {
        Walk();
    }

    private void OnDrawGizmos() // Debug Para ver la ruta
    {
        Gizmos.color = new Color(1, 0, 0, .35f);

        if (_Debug)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                if (i > 0)
                {
                    
                    Gizmos.DrawLine(Points[i - 1], Points[i]);
                }
                if (i == Points.Count - 1)
                {
                    Gizmos.DrawLine(Points[i], Points[0]);
                }
            }
        }
    }

    private void Walk()
    {
        ActPos = transform.position;
        
        if (ActPos.x > OldPos.x)
        {
            Sprite.flipX = true;
            OldPos = ActPos;
        }
        else if(ActPos.x < OldPos.x)
        {
            Sprite.flipX = false;
            OldPos = ActPos;
        }

        transform.position = Vector3.MoveTowards(transform.position, Points[x], speed * Time.deltaTime);

        if (ActPos == Points[x]) // Compureba la posicion
        {
            x++;
            if (x == Points.Count)
            {
                x = 0;
            }
        }
    }
}
