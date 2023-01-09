using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class LaseSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Laser;
    [SerializeField] private GameObject LaserAlert;
    [SerializeField] private int WaveNumber = 3;
    [SerializeField] private int MaxLaser = 3;
    [SerializeField] private int MinLaser = 15;
    private int Wave = 0;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <= WaveNumber; i++)
        {
            if (Wave == i)
            {
                Debug.Log("Wave: " + i);
                StopAllCoroutines();
                StartCoroutine(Wavee(Random.Range(MinLaser, MaxLaser)));

                if (i >= WaveNumber)
                {
                    Wave = 0;
                    StopAllCoroutines();
                    for (int z = 0; z < transform.childCount; z++)
                    {
                        Destroy(transform.GetChild(0).gameObject);
                    }
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    IEnumerator Wavee(int N)
    {
        Wave += 1000;
        List<float> pts = new List<float>();

        for (int i = 0; i < N; i++)
        {
            pts.Add(Random.Range(170, 198));
            Instantiate(LaserAlert, new Vector2(pts[i], transform.position.y + 20), Quaternion.Euler(0, 0, 0), null);
        }
        yield return new WaitForSeconds(1);

        for (int i = 0; i < pts.Count; i++)
        {
            Instantiate(Laser, new Vector2(pts[i], transform.position.y + 20), Quaternion.Euler(0, 0, 0), null);
        }
        yield return new WaitForSeconds(2);
        Wave -= 999;
    }
}
