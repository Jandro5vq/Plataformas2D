using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject UIMng;

    private int Lifes;

    // Update is called once per frame
    void Update()
    {
        Lifes = UIMng.GetComponent<UI_Manager>().Life;

        if (Lifes <=0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
