using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] GameObject BulletWave1;
    [SerializeField] GameObject BulletWave2;
    [SerializeField] GameObject BulletWave3;
    [SerializeField] GameObject LaserWave;

    private bool SStart=false;
    public int WaveTurn = 0;

    // Start is called before the first frame update
    void Update()
    {
        if (SStart)
        {
            if (WaveTurn == 0)
            {
                StopAllCoroutines();
                StartCoroutine(W1());
            }
            else if (WaveTurn == 1)
            {
                StopAllCoroutines();
                StartCoroutine(W2());
            }
            else if (WaveTurn == 2)
            {
                StopAllCoroutines();
                StartCoroutine(W3());
            }
            else if (WaveTurn == 3)
            {
                StopAllCoroutines();
                StartCoroutine(LW());
            }
            else if (WaveTurn == 1003)
            {
                StopAllCoroutines();
                WaveTurn = 0;
                this.enabled = false;
            }
        }
    }

    IEnumerator W1()
    {
        WaveTurn += 1000;
        Debug.Log("BOSS WAVE 1");
        yield return new WaitForSeconds(4);
        BulletWave1.gameObject.SetActive(true);
        yield return new WaitForSeconds(8);
        BulletWave1.gameObject.SetActive(false);
        yield return new WaitForSeconds(4);
        WaveTurn -= 999;
    }

    IEnumerator W2()
    {
        WaveTurn += 1000;
        Debug.Log("BOSS WAVE 2");
        BulletWave2.gameObject.SetActive(true);
        yield return new WaitForSeconds(8);
        BulletWave2.gameObject.SetActive(false);
        yield return new WaitForSeconds(4);
        WaveTurn -= 999;
    }

    IEnumerator W3()
    {
        WaveTurn += 1000;
        Debug.Log("BOSS WAVE 3");
        BulletWave3.gameObject.SetActive(true);
        yield return new WaitForSeconds(8);
        BulletWave3.gameObject.SetActive(false);
        yield return new WaitForSeconds(4);
        WaveTurn -= 999;
    }

    IEnumerator LW()
    {
        WaveTurn += 1000;
        Debug.Log("BOSS WAVE 4");
        LaserWave.gameObject.SetActive(true);
        yield return new WaitForSeconds(10);
        WaveTurn -= 999;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            SStart = true;
        }
    }
}
