using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("Numero de 'Chorros'")]
    [Range(1,360)]
    [SerializeField] private int N = 1;
    [Header("Velocidad de Rotacion")]
    [Range(0, 100)]
    [SerializeField] private int R = 1;
    [Header("Retraso (Segundos)")]
    [SerializeField] private float D = 1;
    [Header("Velocidad de las balas")]
    [SerializeField] private float V = 1;
    [Header("Tiempo de vida de las balas")]
    [SerializeField] private float L = 1;
    [Header("Tipo de Bala a disparar")]
    [SerializeField] private int BT = 0;

    [SerializeField] private List<GameObject> Bullets = new List<GameObject>();



    public bool can = true;

    private void Update()
    {
        if (can)
        {
            StartCoroutine(Shot(D));
        }
        
        transform.rotation = Quaternion.Euler(0,0, transform.rotation.eulerAngles.z + (R * Time.deltaTime));
    }

    private IEnumerator Shot(float D)
    {
        can = false;

        float Dir = 360 / N;
        
        for (int i = 0; i < N; i++)
        {
            GameObject B = Instantiate(Bullets[BT], transform.position, Quaternion.Euler(0, 0,Dir * i), null);
            B.GetComponent<BulletMovement>().Speed = V;
            B.GetComponent<BulletMovement>().Delay = L;
        }

        yield return new WaitForSeconds(D);

        can = true;
    }

}
