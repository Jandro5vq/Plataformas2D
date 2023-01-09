using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject UIMng;

    private int Lifes;

    // Update is called once per frame
    void Update()
    {
        Lifes = UIMng.GetComponent<UI_Manager>().Life;
    }
}
