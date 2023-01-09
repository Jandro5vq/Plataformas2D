using System.Collections;
using TMPro;
using UnityEngine;

public class PC_Logic : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt;
    [SerializeField] GameObject ADoor;
    [TextArea] public string wText0;
    [TextArea] public string wText1;
    [SerializeField] float delayBeforeStart = 0f;
    [SerializeField] float timeBtwChars = 0.1f;

    private string wT;

    private void OnEnable()
    {
        if (ADoor.GetComponent<DoorMechanism>().Open)
        {
            wT = wText1;
        }
        else
        {
            wT = wText0;
        }

        StartCoroutine("TypeWriterTMP");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ADoor.GetComponent<DoorMechanism>().Open = true;

            Time.timeScale = 1f;
            this.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.U))
        {
            Time.timeScale = 1f;
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator TypeWriterTMP()
    {
        txt.text = "";

        yield return new WaitForSecondsRealtime(delayBeforeStart);

        foreach (char c in wT)
        {
            if (txt.text.Length > 0)
            {
                txt.text = txt.text.Substring(0, txt.text.Length);
            }
            txt.text += c;
            yield return new WaitForSecondsRealtime(timeBtwChars);
        }

    }
}
